/*
 * The MIT License (MIT)
 *
 * Copyright (c) 2020 Foorack
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

#define NO_DEBUG
// Remove NO_ to enable debug

using UnityEngine;
using UdonSharp;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBeMadeStatic.Global
// ReSharper disable SuggestBaseTypeForParameter
// ReSharper disable once InconsistentNaming
public class UdonXML : UdonSharpBehaviour
{
    private object[] GenerateEmptyStruct()
    {
        var emptyStruct = new object[4];
        emptyStruct[0] = ""; // nodeName
        var attr = new object[2];
        attr[0] = new string[0];
        attr[1] = new string[0];
        emptyStruct[1] = attr;
        emptyStruct[2] = new object[0];
        emptyStruct[3] = ""; // nodeValue

        return emptyStruct;
    }

    private string[] AddToStringArray(string[] a, string b)
    {
        string[] n = new string[a.Length + 1];
        for (int i = 0; i != a.Length; i++)
        {
            n[i] = a[i];
        }

        n[a.Length] = b;
        return n;
    }

    private object[] AddToObjectArray(object[] a, object b)
    {
        object[] n = new object[a.Length + 1];
        for (int i = 0; i != a.Length; i++)
        {
            n[i] = a[i];
        }

        n[a.Length] = b;
        return n;
    }

    private int[] AddToIntegerArray(int[] a, int b)
    {
        int[] n = new int[a.Length + 1];
        for (int i = 0; i != a.Length; i++)
        {
            n[i] = a[i];
        }

        n[a.Length] = b;
        return n;
    }

    private int[] RemoveFirstIntegerArray(int[] a)
    {
        int[] n = new int[a.Length - 1];
        for (int i = 0; i != a.Length - 1; i++)
        {
            n[i] = a[i + 1];
        }

        return n;
    }

    private int[] RemoveLastIntegerArray(int[] a)
    {
        int[] n = new int[a.Length - 1];
        for (int i = 0; i != a.Length - 1; i++)
        {
            n[i] = a[i];
        }

        return n;
    }

    private object[] FindCurrentLevel(object[] data, int[] position)
    {
        if (position.Length == 0)
        {
            return data;
        }

        object[] current = data;

#if DEBUG
        Debug.Log("FCL Start");
#endif

        // [ 1, 0, 1]
        while (position.Length != 0)
        {
#if DEBUG
            Debug.Log("FCL: " + position[0] + " " + ((object[]) current[2]).Length);
#endif
            current = (object[]) ((object[]) current[2])[position[0]];
            position = RemoveFirstIntegerArray(position);
        }

        return current;
    }

    private object[] Parse(char[] input)
    {
        int state = 0;
        int level = 0;
        bool isSpecialData = false;
        bool isWithinQuotes = false;
        bool isSelfClosingNode = false;
        bool hasNodeNameEnded = false;
        bool hasTagSplitOccured = false; // means the = between the name and the value

        object[] data = GenerateEmptyStruct();
        data[0] = "UdonXMLRoot";

        // Position to know where we are in the tree.
        int[] position = new int[0];

        string nodeName = "";
        string tagName = "";
        string tagValue = "";
        string[] tagNames = new string[0];
        string[] tagValues = new string[0];

        int i = 0;
        for (; i != input.Length; i++)
        {
            char c = input[i];
            string pos = "";
            for (int n = 0; n != position.Length; n++)
            {
                pos += position[n] + ">";
            }

#if DEBUG
            Debug.Log(state + " " + level + " " + c + "   " + pos);
#endif

            if (state == 0)
            {
                if (c == '<')
                {
                    isSpecialData = false;
                    isWithinQuotes = false;
                    isSelfClosingNode = false;
                    hasNodeNameEnded = false;
                    hasTagSplitOccured = false;
                    nodeName = "";
                    tagNames = new string[0];
                    tagValues = new string[0];
                    state = 1;
                }
                else
                {
                    object[] s = FindCurrentLevel(data, position);
                    s[3] = (string) s[3] + c;
                }
            }
            else if (state == 1)
            {
                if (c == '/')
                {
                    state = 2;
                }
                else
                {
                    if (c == '?')
                    {
                        isSpecialData = true;
                    }

                    nodeName += c + "";
                    state = 3;
                }
            }
            else if (state == 2)
            {
                if (c == '>')
                {
                    level--;
                    position = RemoveLastIntegerArray(position);

                    state = 0;
#if DEBUG
                    Debug.Log("CLOSED TAG : " + nodeName);
#endif
                }
                else
                {
                    nodeName += c + "";
                }
            }
            else if (state == 3)
            {
                if (c == '>' && !isWithinQuotes)
                {
#if DEBUG
                    Debug.Log("OPENED TAG : " + nodeName);
#endif
                    state = 0;

                    // Add tag
                    if (tagName.Trim().Length != 0)
                    {
                        tagNames = AddToStringArray(tagNames, tagName);
                        tagValues = AddToStringArray(tagValues, tagValue);
                        tagName = "";
                        tagValue = "";
                        hasTagSplitOccured = false;
                    }

                    if (!isSpecialData)
                    {
                        object[] s = FindCurrentLevel(data, position);
                        position = AddToIntegerArray(position, ((object[]) s[2]).Length);

                        s[2] = AddToObjectArray((object[]) s[2], GenerateEmptyStruct());
                        object[] children = (object[]) s[2];
                        object[] child = (object[]) children[children.Length - 1];

                        child[0] = nodeName;
                        object[] attr = (object[]) child[1];
                        attr[0] = tagNames;
                        attr[1] = tagValues;

                        if (isSelfClosingNode)
                        {
                            position = RemoveLastIntegerArray(position);
#if DEBUG
                            Debug.Log("SELF-CLOSED TAG : " + nodeName);
#endif
                        }
                        else
                        {
                            level++;
                        }
                    }
                }
                else if (c == '/' && !isWithinQuotes)
                {
                    isSelfClosingNode = true;
                }
                else if (c == '"')
                {
                    isWithinQuotes = !isWithinQuotes;
                }
                else if (c == ' ')
                {
                    if (!hasNodeNameEnded)
                    {
                        hasNodeNameEnded = true;
                    }
                    else
                    {
                        // Add tag
                        if (tagName.Trim().Length != 0)
                        {
                            tagNames = AddToStringArray(tagNames, tagName);
                            tagValues = AddToStringArray(tagValues, tagValue);
                            tagName = "";
                            tagValue = "";
                            hasTagSplitOccured = false;
                        }
                    }
                }
                else if (c == '=' && !isWithinQuotes)
                {
                    hasTagSplitOccured = true;
                }
                else
                {
                    if (hasNodeNameEnded)
                    {
                        // if tag name or tag value
                        if (hasTagSplitOccured)
                        {
                            tagValue += c + "";
                        }
                        else
                        {
                            tagName += c + "";
                        }
                    }
                    else
                    {
                        nodeName += c + "";
                    }
                }
            }
        }

        return level != 0 ? null : data;
    }

    /**
     * Loads an XML structure into memory by parsing a char[] provided input.
     *
     * Returns null in case of parse failure.
     */
    public object LoadXml(char[] input)
    {
        return Parse(input);
    }

    /**
     * Returns true if the node has child nodes.
     */
    public bool HasChildNodes(object data)
    {
        return ((object[]) ((object[]) data)[2]).Length != 0;
    }

    /**
     * Returns the number of children the current node has.
     */
    public int GetChildNodesCount(object data)
    {
        return ((object[]) ((object[]) data)[2]).Length;
    }

    /**
     * Returns the child node by the given index.
     */
    public object GetChildNode(object data, int index)
    {
        return (object[]) ((object[]) ((object[]) data)[2])[index];
    }

    /**
     * Returns the child node by the given name.
     * If multiple nodes exists with the same type-name then the first one will be returned.
     */
    public object GetChildNodeByName(object data, string nodeName)
    {
        var children = (object[]) ((object[]) data)[2];

        for (var i = 0; i != children.Length; i++)
        {
            var child = (object[]) children[i];
            if (((string) child[0]) == nodeName)
            {
                return child;
            }
        }

        return null;
    }

    /**
     * Returns the type-name of the node.
     */
    public string GetNodeName(object data)
    {
        return (string) ((object[]) data)[0];
    }

    /**
     * Returns the value of the node.
     */
    public string GetNodeValue(object data)
    {
        return (string) ((object[]) data)[3];
    }

    /**
     * Returns whether the node has a given attribute or not. 
     */
    public bool HasAttribute(object data, string attrName)
    {
        var attr = (object[]) ((object[]) data)[1];
        var tagNames = (string[]) attr[1];

        for (var i = 0; i != tagNames.Length; i++)
        {
            if (tagNames[i] == attrName)
            {
                return true;
            }
        }

        return false;
    }

    /**
     * Returns the value of the attribute by given name.
     */
    public string GetAttribute(object data, string attrName)
    {
        var attr = (object[]) ((object[]) data)[1];
        var tagNames = (string[]) attr[1];
        var tagValues = (string[]) attr[1];

        for (var i = 0; i != tagNames.Length; i++)
        {
            if (tagNames[i] == attrName)
            {
                return tagValues[i];
            }
        }

        return null;
    }
}