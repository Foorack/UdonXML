# UdonXML

[![Discord](https://img.shields.io/badge/Discord-Discord%20Support-blueviolet?logo=discord)](https://discord.gg/7xJdWNk) - Feel free to join if you have any bugs or questions!

## Setup

### Requirements

* Unity 2018.4.20f1
* VRCSDK3
* [UdonSharp](https://github.com/Merlin-san/UdonSharp/blob/master/README.md)

### Installation

1. Go to [Releases](https://github.com/Foorack/UdonXML/releases) and download the latest release. The file should end with `unitypackage`. If you can't find it, ask for help on Discord.
2. Import the package into Unity with Assets > Import Package > Custom Package. This will import the files to `Resources > Foorack > UdonXML`.
3. Create an Empty GameObject in your Scene, name it `UdonXML` and assign it the UdonXML UdonBehaviour.

### Getting started

1. Declare a `public UdonXML udonXml;` variable in your program.
2. Assign it the value of the UdonXML GameObject in your scene.
3. Parse your XML data with LoadXml `udonXml.LoadXml(inputData.ToCharArray());`. It will return an object. Notice it takes a char[] and not a string as input, so ToCharArray is required.
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
        var root = udonXml.LoadXml(EXAMPLE_DATA.ToCharArray());

        var books = udonXml.GetChildNode(root, 0);

        for (var bookNum = 0; bookNum != udonXml.GetChildNodesCount(books); bookNum++)
        {
            var book = udonXml.GetChildNode(books, bookNum);
            var title = udonXml.GetChildNodeByName(book, "title");
            var price = udonXml.GetChildNodeByName(book, "price");

            Debug.Log("title: " + udonXml.GetNodeValue(title) + " price: " + udonXml.GetNodeValue(price));
        }
    }
}
```

![console output](https://i.imgur.com/g0e3ooO.png)

## Documentation

### Parsing


#### LoadXml(char[] input
Loads an XML structure into memory by parsing a char[] provided input.

Returns null in case of parse failure.


### Reading data

#### HasChildNodes(object data)
Returns true if the node has child nodes.

#### GetChildNodesCount(object data)
Returns the number of children the current node has.

#### GetChildNode(object data, int index)
Returns the child node by the given index.

#### GetChildNodeByName(object data, string nodeName)
Returns the child node by the given name.

If multiple nodes exists with the same type-name then the first one will be returned.

#### GetNodeName(object data)
Returns the type-name of the node.

#### GetNodeValue(object data)
Returns the value of the node.

#### HasAttribute(object data, string attrName)
Returns whether the node has a given attribute or not.

#### GetAttribute(object data, string attrName)
Returns the value of the attribute by given name.


## Roadmap

* Parsing from in-memory back to an XML document.
* Allowing setting values and creating nodes.
* Improve error detection / make it stricter. Right now it allows closing tag to have a different name from opening tag, and only goes by level depth.
* Add support for DOCTYPE and storing the ?xml declaration.

Functionality of validating an XML document's compliance against an XML Schema is very far-reach and out-of-scope for the foreseeable future.