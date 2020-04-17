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

/*
 *     UdonXML
 *
 *     Version log:
 *         0.1.0: 2020-04-11; Initial version, parsing capability.
 *         0.1.1: 2020-04-12; Added support for !DOCTYPE, thereby allowing HTML to be parsed.
 *         0.1.2: 2020-04-12; Many parsing issues fixed. Now possible to export XML data.
 *         0.1.3: 2020-04-12; Added ability to change values and create/delete attributes and child nodes.
 * 
 */

#define NO_DEBUG
// Remove NO_ to enable debug

using UnityEngine;
using UdonSharp;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBeMadeStatic.Global
// ReSharper disable SuggestBaseTypeForParameter
// ReSharper disable once InconsistentNaming
public class UdonXML : UdonSharpBehaviour
{
    /**
     * Data is stored internally in the following format:
     *
     * object[]{ 
     *     0: "nodeName",
     *     1: object[ // attributes
     *  	    tagNames,
     *  	    tagValue
     *     ],
     *     2: object[ //children
     *  	    // self...
     *     ]
     *     3: "value"
     * }
     */
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

    private string[] AddLastToStringArray(string[] a, string b)
    {
        var n = new string[a.Length + 1];
        for (var i = 0; i != a.Length; i++)
        {
            n[i] = a[i];
        }

        n[a.Length] = b;
        return n;
    }

    private string[] RemoveIndexStringArray(string[] a, int index)
    {
        var n = new string[a.Length - 1];
        for (var i = 0; i < index; i++)
        {
            n[i] = a[i];
        }

        for (var i = index + 1; i != a.Length - 1; i++)
        {
            n[i - 1] = a[i];
        }

        return n;
    }

    private object[] AddFirstToObjectArray(object[] a, object b)
    {
        var n = new object[a.Length + 1];
        for (var i = 0; i != a.Length; i++)
        {
            n[i + 1] = a[i];
        }

        n[0] = b;
        return n;
    }

    private object[] AddLastToObjectArray(object[] a, object b)
    {
        var n = new object[a.Length + 1];
        for (var i = 0; i != a.Length; i++)
        {
            n[i] = a[i];
        }

        n[a.Length] = b;
        return n;
    }

    private object[] RemoveFirstObjectArray(object[] a)
    {
        var n = new object[a.Length - 1];
        for (var i = 0; i != a.Length - 1; i++)
        {
            n[i] = a[i + 1];
        }

        return n;
    }

    private object[] RemoveIndexObjectArray(object[] a, int index)
    {
        var n = new object[a.Length - 1];
        for (var i = 0; i < index; i++)
        {
            n[i] = a[i];
        }

        for (var i = index + 1; i != a.Length - 1; i++)
        {
            n[i - 1] = a[i];
        }

        return n;
    }

    private int[] AddLastToIntegerArray(int[] a, int b)
    {
        var n = new int[a.Length + 1];
        for (var i = 0; i != a.Length; i++)
        {
            n[i] = a[i];
        }

        n[a.Length] = b;
        return n;
    }

    private int[] RemoveFirstIntegerArray(int[] a)
    {
        var n = new int[a.Length - 1];
        for (var i = 0; i != a.Length - 1; i++)
        {
            n[i] = a[i + 1];
        }

        return n;
    }

    private int[] RemoveLastIntegerArray(int[] a)
    {
        var n = new int[a.Length - 1];
        for (var i = 0; i != a.Length - 1; i++)
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

        var current = data;

        // [ 1, 0, 1]
        while (position.Length != 0)
        {
            current = (object[]) ((object[]) current[2])[position[0]];
            position = RemoveFirstIntegerArray(position);
        }

        return current;
    }

    private object[] Parse(char[] input)
    {
        var state = 0;
        var level = 0;
        var isSpecialData = false;
        var isWithinQuotes = false;
        var isSelfClosingNode = false;
        var hasNodeNameEnded = false;
        var hasTagSplitOccured = false; // means the = between the name and the value

        var data = GenerateEmptyStruct();
        data[0] = "UdonXMLRoot";

        // Position to know where we are in the tree.
        var position = new int[0];

        var nodeName = "";
        var tagName = "";
        var tagValue = "";
        var tagNames = new string[0];
        var tagValues = new string[0];

        for (var i = 0; i != input.Length; i++)
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
                    if (c == '?' || c == '!')
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
                    tagName = "";
                    tagValue = "";

                    var s = FindCurrentLevel(data, position);
                    position = AddLastToIntegerArray(position, ((object[]) s[2]).Length);

                    s[2] = AddLastToObjectArray((object[]) s[2], GenerateEmptyStruct());
                    var children = (object[]) s[2];
                    var child = (object[]) children[children.Length - 1];

                    child[0] = nodeName;
                    var attr = (object[]) child[1];
                    attr[0] = tagNames;
                    attr[1] = tagValues;

                    if (isSelfClosingNode || isSpecialData)
                    {
                        position = RemoveLastIntegerArray(position);
#if DEBUG
                        Debug.Log("SELF-CLOSED TAG : " + nodeName);
#endif
                    }

                    if (!isSelfClosingNode && !isSpecialData)
                    {
                        level++;
                    }
                }

                else if (c == '/' && !isWithinQuotes)
                {
                    isSelfClosingNode = true;
                }
                else if (c == '"')
                {
                    if (isWithinQuotes)
                    {
                        // Add tag
                        if (tagName.Trim().Length != 0)
                        {
                            tagNames = AddLastToStringArray(tagNames, tagName.Trim());
                            tagValues = AddLastToStringArray(tagValues, tagValue);
                            tagName = "";
                            tagValue = "";
                            hasTagSplitOccured = false;
                        }
                    }

                    isWithinQuotes = !isWithinQuotes;
                }
                else if (c == '=' && !isWithinQuotes)
                {
                    hasTagSplitOccured = true;
                }
                else
                {
                    if (c == ' ' && !hasNodeNameEnded)
                    {
                        hasNodeNameEnded = true;
                        var nodeNameLow = nodeName.ToLower();
                        if (nodeNameLow == "area" || nodeNameLow == "base" || nodeNameLow == "br" ||
                            nodeNameLow == "embed" || nodeNameLow == "hr" || nodeNameLow == "iframe" ||
                            nodeNameLow == "img" || nodeNameLow == "input" || nodeNameLow == "link" ||
                            nodeNameLow == "meta" || nodeNameLow == "param" || nodeNameLow == "source" ||
                            nodeNameLow == "track")
                        {
                            isSelfClosingNode = true;
                        }
                    }

                    if (hasNodeNameEnded)
                    {
                        // if tag name or tag value
                        if (hasTagSplitOccured)
                        {
                            tagValue += c + "";
                        }
                        else
                        {
                            // i.e. bordered in <table>, or html in <doctype>, sometimes they don't have values
                            if (c == ' ')
                            {
                                // Add tag
                                if (tagName.Trim().Length != 0)
                                {
                                    tagNames = AddLastToStringArray(tagNames, tagName.Trim());
                                    tagValues = AddLastToStringArray(tagValues, null);
                                    tagName = "";
                                }
                            }
                            else
                            {
                                tagName += c + "";
                            }
                        }
                    }
                    else
                    {
                        nodeName += c + "";
                    }
                }
            }
        }

#if DEBUG
        Debug.Log("Level after parsing: " + level);
#endif
        return level != 0 ? null : data;
    }

    private string Serialize(object[] data, string padding)
    {
        var output = "";

        var work = new object[0];
        var current = data;

        var nodeChildren = (object[]) current[2];
        // Add all current children
        foreach (object o in nodeChildren)
        {
            work = AddLastToObjectArray(work, new[] {o, 0});
        }

        while (work.Length != 0)
        {
            current = (object[]) work[0];
            var node = (object[]) current[0];
            var level = (int) current[1];
            work = RemoveFirstObjectArray(work);
            var nodeName = (string) node[0];
            var nodeTags = (object[]) node[1];
            var tagNames = (object[]) nodeTags[0];
            var tagValues = (object[]) nodeTags[1];
            nodeChildren = (object[]) node[2];
            var nodeValue = (string) node[3];
#if DEBUG
            Debug.Log("[UdonXML] [Save] Work: " + nodeName + " " + level);
#endif

            // Add newline if not first line
            if (output.Length != 0)
            {
                output += "\n";
            }

            // Add indentation
            for (var i = 0; i != level; i++)
            {
                output += padding;
            }

            // Compile tags list
            var tagList = "";
            for (var i = 0; i != tagNames.Length; i++)
            {
                if (null == tagValues[i])
                {
                    // Tags without value, such as bordered in table, or html in doctype
                    tagList += " " + tagNames[i];
                }
                else
                {
                    tagList += " " + tagNames[i] + "=\"" + tagValues[i] + "\"";
                }
            }

            if (nodeChildren.Length == 0)
            {
                if (nodeValue.Trim().Length == 0)
                {
                    var nodeNameLow = nodeName.ToLower();
                    switch (nodeNameLow)
                    {
                        // ?xml has an extra ? at the end
                        case "?xml":
                            output += $"<{nodeName}{tagList}?>";
                            break;
                        // doc types are self closing without the usual slash
                        case "!doctype":
                            output += $"<{nodeName}{tagList}>";
                            break;
                        case "!--":
                            output += $"<{nodeName}{tagList} -->";
                            break;
                        default:
                            output += $"<{nodeName}{tagList} />";
                            break;
                    }
                }
                else
                {
                    output += $"<{nodeName}{tagList}>{nodeValue}</{nodeName}>";
                }
            }
            else
            {
                output += $"<{nodeName}{tagList}>";
                if (nodeChildren[0] != null)
                {
                    var tempData = GenerateEmptyStruct();
                    tempData[0] = "/" + nodeName;
                    tempData[2] = new object[] {null};
                    work = AddFirstToObjectArray(work, new object[] {tempData, level});
                }
            }

            // Add all current children
            for (var i = nodeChildren.Length - 1; i >= 0; i--)
            {
                var o = nodeChildren[i];
                if (o != null)
                {
                    work = AddFirstToObjectArray(work, new[] {o, level + 1});
                }
            }
        }

        return output;
    }

    /**
     * Loads an XML structure into memory by parsing the provided input.
     *
     * Returns null in case of parse failure.
     */
    public object LoadXml(string input)
    {
        return Parse(input.ToCharArray());
    }

    /**
     * Saves the stored XML structure in memory to an XML document.
     * Uses default indent of 4 spaces. Use `SaveXmlWithIdent` to override.
     */
    public string SaveXml(object data)
    {
        return SaveXmlWithIdent(data, "    ");
    }

    /**
     * Saves the stored XML structure in memory to an XML document with given indentation.
     */
    public string SaveXmlWithIdent(object data, string indent)
    {
        return Serialize((object[]) data, indent);
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
     * 
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
     * Creates a new child node under the current given node.
     *
     * Returns the newly created node.
     */
    public object CreateChildNode(object data, string nodeName)
    {
        var newChild = GenerateEmptyStruct();
        newChild[0] = nodeName;
        var d = (object[]) data;
        d[2] = AddLastToObjectArray((object[]) d[2], newChild);
        return newChild;
    }

    /**
     * Removes a child node from the current node by given index.
     *
     * Returns the deleted node.
     */
    public object RemoveChildNode(object data, int index)
    {
        var d = (object[]) data;
        var old = ((object[]) d[2])[index];
        d[2] = RemoveIndexObjectArray((object[]) d[2], index);
        return old;
    }

    /**
     * Removes a child node from the current node by given name. If multiple nodes exist with the same name then only the first one is deleted.
     *
     * Returns the deleted node, or null if not found.
     */
    public object RemoveChildNodeByName(object data, string nodeName)
    {
        var d = (object[]) data;
        var children = (object[]) d[2];
        for (var i = 0; i != children.Length; i++)
        {
            var old = (object[]) children[i];
            if ((string) old[0] == nodeName)
            {
                d[2] = RemoveIndexObjectArray(children, i);
                return old;
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
     * Sets the name of the node.
     */
    public void SetNodeName(object data, string newName)
    {
        ((object[]) data)[0] = newName;
    }

    /**
     * Returns the value of the node.
     */
    public string GetNodeValue(object data)
    {
        return (string) ((object[]) data)[3];
    }

    /**
     * Sets the value of the node.
     */
    public void SetNodeValue(object data, string newValue)
    {
        ((object[]) data)[3] = newValue;
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

    /**
     * Sets the value of an attribute on given node.
     *
     * Returns false if the attribute already existed, returns true if attribute was created. 
     */
    public bool SetAttribute(object data, string attrName, string newValue)
    {
        var attr = (object[]) ((object[]) data)[1];
        var tagNames = (string[]) attr[1];
        var tagValues = (string[]) attr[1];

        for (var i = 0; i != tagNames.Length; i++)
        {
            if (tagNames[i] == attrName)
            {
                tagValues[i] = newValue;
                return false;
            }
        }

        // This only executes if it wasn't already found
        attr[0] = AddLastToStringArray(tagNames, attrName);
        attr[1] = AddLastToStringArray(tagValues, newValue);
        return true;
    }

    /**
     * Removes an attribute by name in the given node.
     *
     * Returns true if attribute was deleted, false if it did not exist.
     */
    public bool RemoveAttribute(object data, string attrName)
    {
        var attr = (object[]) ((object[]) data)[1];
        var tagNames = (string[]) attr[1];
        var tagValues = (string[]) attr[1];

        for (var i = 0; i != tagNames.Length; i++)
        {
            if (tagNames[i] == attrName)
            {
                attr[0] = RemoveIndexStringArray(tagNames, i);
                attr[1] = RemoveIndexStringArray(tagValues, i);
                return true;
            }
        }

        return false;
    }
}