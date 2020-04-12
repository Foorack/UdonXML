# UdonXML

[![Discord](https://img.shields.io/badge/Discord-Discord%20Support-blueviolet?logo=discord)](https://discord.gg/7xJdWNk) - Feel free to join if you have any bugs or questions!

UdonXML is an XML parser written in Udon for VRChat.
The purpose of this project is for it to be used as an API in other bigger projects.
This work is something the average VRChatter never will notice, but something the author hopes might be beneficial and make the life easier for world/game creators in VRChat.

An example use of this library is allowing the player to paste the entire contents of an XML file (e.g. game save file) into an Input field in VRC, and allowing the world to then parse the submitted data.
Work is currently undergoing on implementing a ZIP decoder for this same purpose, please join the Discord for notification on future updates.

## 🛠️ Setup

### Requirements

* Unity 2018.4.20f1
* VRCSDK3
* Latest [UdonSharp](https://github.com/Merlin-san/UdonSharp/blob/master/README.md)

### Installation

1. Go to [Releases](https://github.com/Foorack/UdonXML/releases) and download the latest release. The file should end with `unitypackage`. If you can't find it, ask for help on Discord.
2. Import the package into Unity with Assets > Import Package > Custom Package. This will import the files to `Resources > Foorack > UdonXML`.
3. Create an Empty GameObject in your Scene, name it `UdonXML` and assign it the UdonXML UdonBehaviour.

### Getting started

1. Declare a `public UdonXML udonXml;` variable in your program.
2. Assign it the value of the UdonXML GameObject in your scene.
3. Parse your XML data with LoadXml `udonXml.LoadXml(inputData);`. It will return an object.
4. The object returned represents the root of the xml tree, use it when executing other nodes such as `GetNodeName` or `HasChildNodes`.

### Example demo

```csharp
using UnityEngine;
using UdonSharp;

public class UdonXMLTest : UdonSharpBehaviour
{
    public UdonXML udonXml;

    private string EXAMPLE_DATA = @"<?xml version=""1.0"" encoding=""utf-8""?>  
<books xmlns=""http://www.contoso.com/books"">  
    <book genre=""novel"" ISBN=""1-861001-57-8"" publicationdate=""1823-01-28"">  
        <title>Pride And Prejudice</title>  
        <price>24.95</price>  
    </book>
    <book genre=""novel"" ISBN=""1-861002-30-1"" publicationdate=""1985-01-01"">  
        <title>The Handmaid's Tale</title>  
        <price>29.95</price>  
    </book>  
    <book genre=""novel"" ISBN=""1-861001-45-3"" publicationdate=""1811-01-01"">  
        <title>Sense and Sensibility</title>  
        <price>19.95</price>  
    </book>  
</books>";

    public void Start()
    {
        // Parse and store the root node
        var root = udonXml.LoadXml(EXAMPLE_DATA);

        // Fetch the first <books> node by index
        var books = udonXml.GetChildNode(root, 1); // Index 0 will be <?xml> tag

        // Loop over all children in the <books> node
        for (var bookNum = 0; bookNum != udonXml.GetChildNodesCount(books); bookNum++)
        {
            var book = udonXml.GetChildNode(books, bookNum);
            // Fetch <title> and <price> nodes by tag name.
            var title = udonXml.GetChildNodeByName(book, "title");
            var price = udonXml.GetChildNodeByName(book, "price");

            Debug.Log("title: " + udonXml.GetNodeValue(title) + " price: " + udonXml.GetNodeValue(price));
        }
    }
}
```

![console output](https://i.imgur.com/g0e3ooO.png)

## 📄 Documentation

### Loading data

#### 🟣 object LoadXml(string input)
Loads an XML structure into memory by parsing the provided input.

Returns null in case of parse failure.


### Saving data

#### 🟤 string SaveXml(object data)
Saves the stored XML structure in memory to an XML document.

Uses default indent of 4 spaces. Use `SaveXmlWithIdent` to override.

#### 🟤 string SaveXmlWithIdent(object data, string indent)
Saves the stored XML structure in memory to an XML document with given indentation.


### Reading data

#### 🔵 bool HasChildNodes(object data)
Returns true if the node has child nodes.

#### 🔵 int GetChildNodesCount(object data)
Returns the number of children the current node has.

#### 🔵 object GetChildNode(object data, int index)
Returns the child node by the given index.

#### 🔵 object GetChildNodeByName(object data, string nodeName)
Returns the child node by the given name.

If multiple nodes exists with the same type-name then the first one will be returned.

#### 🔵 string GetNodeName(object data)
Returns the type-name of the node.

#### 🔵 string GetNodeValue(object data)
Returns the value of the node.

#### 🔵 bool HasAttribute(object data, string attrName)
Returns whether the node has a given attribute or not.

#### 🔵 string GetAttribute(object data, string attrName)
Returns the value of the attribute by given name.


### Writing data

#### 🟠 object CreateChildNode(object data, string nodeName)
Creates a new child node under the current given node.

Returns the newly created node.

#### 🟠 object RemoveChildNode(object data, int index)
Removes a child node from the current node by given index.

Returns the deleted node.

#### 🟠 object RemoveChildNode(object data, string nodeName)
Removes a child node from the current node by given name.
If multiple nodes exist with the same name then only the first one is deleted.

Returns the deleted node, or null if not found.

#### 🟠 void SetNodeName(object data, string newName)
Sets the name of the node.

#### 🟠 void SetNodeValue(object data, string newValue)
Sets the value of the node.

#### 🟠 void SetAttribute(object data, string attrName, string newValue)
Sets the value of an attribute on given node.

Returns false if the attribute already existed, returns true if attribute was created.

#### 🟠 bool RemoveAttribute(object data, string attrName)
Removes an attribute by name in the given node.

Returns true if attribute was deleted, false if it did not exist.

## 🚛 Roadmap

* ~~Parsing from in-memory back to an XML document.~~
* ~~Allowing setting values and creating nodes.~~
* Improve error detection / make it stricter. Right now it allows closing tag to have a different name from opening tag, and only goes by level depth.
* ~~Add support for DOCTYPE and storing the ?xml declaration.~~

Functionality of validating an XML document's compliance against an XML Schema is very far-reach and out-of-scope for the foreseeable future.