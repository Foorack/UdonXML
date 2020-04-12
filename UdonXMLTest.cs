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

using UnityEngine;
using UdonSharp;

// ReSharper disable once InconsistentNaming
public class UdonXMLTest : UdonSharpBehaviour
{
    public UdonXML udonXml;

    private string EXAMPLE_DATA_1 = @"<users>
    <user name=""John Doe"" age=""42"" />
    <user name=""Jane Doe"" age=""39"" />
</users>";

    private string EXAMPLE_DATA_2 = @"<?xml version=""1.0"" encoding=""utf-8""?>  
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

    private string EXAMPLE_DATA_3 = @"<ManagedTreeData Version=""1"">
  <TreeItem Name=""ProjectDefaultConfigurations"">
    <TreeItem Name=""ProjectDefaultConfiguration"">
      <Attribute Name=""ID"" Type=""Primitive"" ValueType=""String"" Value=""8db44480-2f7b-4495-b3dc-10841b6c375a"" />
      <Attribute Name=""ParameterableType"" Type=""IResourceSerializer"" SerializerName=""LumosTypeSerializer"">
        <TreeItem Name=""SerializedType"">
          <Attribute Name=""Value"" Type=""Primitive"" ValueType=""String"" Value=""org.dmxc.lumos.Kernel.Executor.ExecutorConfiguration, Lumos, Version=3.2.496.0, Culture=neutral, PublicKeyToken=null"" />
        </TreeItem>
      </Attribute>
      <Attribute Name=""ZZ_SAVE_INDEX"" Type=""Primitive"" ValueType=""Int32"" Value=""0"" />
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Name"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""String"" Value=""New Executor"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""FaderMode"" />
        <Attribute Name=""ValueID"" Type=""Primitive"" ValueType=""String"" Value=""Intensity"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#ToggleFlash"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""False"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#ShowProgrammerFilter"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#AutoGO"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""False"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#AutoStop"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""False"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""SwopProtect"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""False"" />
      </TreeItem>
    </TreeItem>
    <TreeItem Name=""ProjectDefaultConfiguration"">
      <Attribute Name=""ID"" Type=""Primitive"" ValueType=""String"" Value=""9723a5c1-e2a1-406e-ba0a-89e590ebd4dd"" />
      <Attribute Name=""ParameterableType"" Type=""IResourceSerializer"" SerializerName=""LumosTypeSerializer"">
        <TreeItem Name=""SerializedType"">
          <Attribute Name=""Value"" Type=""Primitive"" ValueType=""String"" Value=""org.dmxc.lumos.Kernel.Executor.ExecutorPageConfiguration, Lumos, Version=3.2.496.0, Culture=neutral, PublicKeyToken=null"" />
        </TreeItem>
      </Attribute>
      <Attribute Name=""ZZ_SAVE_INDEX"" Type=""Primitive"" ValueType=""Int32"" Value=""1"" />
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Name"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""String"" Value=""New Executor Page"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""ColCount"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Int32"" Value=""8"" />
      </TreeItem>
    </TreeItem>
    <TreeItem Name=""ProjectDefaultConfiguration"">
      <Attribute Name=""ID"" Type=""Primitive"" ValueType=""String"" Value=""344c8ca7-5fe4-46c2-a226-46e350193ca7"" />
      <Attribute Name=""ParameterableType"" Type=""IResourceSerializer"" SerializerName=""LumosTypeSerializer"">
        <TreeItem Name=""SerializedType"">
          <Attribute Name=""Value"" Type=""Primitive"" ValueType=""String"" Value=""org.dmxc.lumos.Kernel.SceneList.SceneListConfiguration, Lumos, Version=3.2.496.0, Culture=neutral, PublicKeyToken=null"" />
        </TreeItem>
      </Attribute>
      <Attribute Name=""DefaultDelayTime"" Type=""IResourceSerializer"" SerializerName=""FannedValueManager"">
        <TreeItem Name=""SerializedIFannedValue"">
          <Attribute Name=""Operator"" Type=""Primitive"" ValueType=""String"" Value="""" />
          <Attribute Name=""Direct"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
          <TreeItem Name=""Value"">
            <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Double"" Value=""0"" />
          </TreeItem>
        </TreeItem>
      </Attribute>
      <Attribute Name=""DefaultFadeTime"" Type=""IResourceSerializer"" SerializerName=""FannedValueManager"">
        <TreeItem Name=""SerializedIFannedValue"">
          <Attribute Name=""Operator"" Type=""Primitive"" ValueType=""String"" Value="""" />
          <Attribute Name=""Direct"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
          <TreeItem Name=""Value"">
            <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Double"" Value=""2000"" />
          </TreeItem>
        </TreeItem>
      </Attribute>
      <Attribute Name=""GoBackTime"" Type=""IResourceSerializer"" SerializerName=""FannedValueManager"">
        <TreeItem Name=""SerializedIFannedValue"">
          <Attribute Name=""Operator"" Type=""Primitive"" ValueType=""String"" Value="""" />
          <Attribute Name=""Direct"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
          <TreeItem Name=""Value"">
            <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Double"" Value=""5000"" />
          </TreeItem>
        </TreeItem>
      </Attribute>
      <Attribute Name=""GoToTime"" Type=""IResourceSerializer"" SerializerName=""FannedValueManager"">
        <TreeItem Name=""SerializedIFannedValue"">
          <Attribute Name=""Operator"" Type=""Primitive"" ValueType=""String"" Value="""" />
          <Attribute Name=""Direct"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
          <TreeItem Name=""Value"">
            <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Double"" Value=""5000"" />
          </TreeItem>
        </TreeItem>
      </Attribute>
      <Attribute Name=""ReleaseTime"" Type=""IResourceSerializer"" SerializerName=""FannedValueManager"">
        <TreeItem Name=""SerializedIFannedValue"">
          <Attribute Name=""Operator"" Type=""Primitive"" ValueType=""String"" Value="""" />
          <Attribute Name=""Direct"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
          <TreeItem Name=""Value"">
            <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Double"" Value=""0"" />
          </TreeItem>
        </TreeItem>
      </Attribute>
      <Attribute Name=""BeatSource"" Type=""Primitive"" ValueType=""String"" Value=""SpeedMaster 1"" />
      <Attribute Name=""ZZ_SAVE_INDEX"" Type=""Primitive"" ValueType=""Int32"" Value=""2"" />
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Priority"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""SByte"" Value=""0"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""SourceForLTPPriority"" />
        <Attribute Name=""ValueID"" Type=""Primitive"" ValueType=""String"" Value=""SourceForLTPPriority#ListStart"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""MixerMode"" />
        <Attribute Name=""ValueID"" Type=""Primitive"" ValueType=""String"" Value=""MixerModeLTP"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""ReleaseMode"" />
        <Attribute Name=""ValueID"" Type=""Primitive"" ValueType=""String"" Value=""ManualOnly"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""PlayMode"" />
        <Attribute Name=""ValueID"" Type=""Primitive"" ValueType=""String"" Value=""Once"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#ResetWhenReleased"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#Tracking"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#ShowProgrammerFilter"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#UseCueTimeAsBackTime"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""False"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#UseCueTimeAsGoToTime"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""False"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#Autoprepare"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""False"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#Skip1StTriggerOnPlay"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""False"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""GoNextBehavior#StartList"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""GoNextBehavior#AlwaysNextIndex"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""False"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""ColumnsVisible#Progress"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""ColumnsVisible#Number"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""ColumnsVisible#Trigger"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""ColumnsVisible#TriggerValue"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""ColumnsVisible#Name"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""ColumnsVisible#Fade"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""ColumnsVisible#Delay"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""ColumnsVisible#Active"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""ColumnsVisible#Autoprepare"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""ColumnsVisible#Comment"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""ColumnsVisible#FadeDown"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""False"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""ColumnsVisible#DelayDown"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""False"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""ColumnsVisible#TakeFades"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""DefaultActiveSource"" />
        <Attribute Name=""ValueID"" Type=""Primitive"" ValueType=""String"" Value=""SetInDefaults"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""DefaultActive"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""DefaultAutoPrepareSource"" />
        <Attribute Name=""ValueID"" Type=""Primitive"" ValueType=""String"" Value=""SetInDefaults"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""DefaultAutoPrepare"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""DefaultCommentSource"" />
        <Attribute Name=""ValueID"" Type=""Primitive"" ValueType=""String"" Value=""SetInDefaults"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""DefaultComment"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""String"" Value="""" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""DefaultDelayTimeSource"" />
        <Attribute Name=""ValueID"" Type=""Primitive"" ValueType=""String"" Value=""SetInDefaults"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""DefaultDelayDownTimeSource"" />
        <Attribute Name=""ValueID"" Type=""Primitive"" ValueType=""String"" Value=""SetInDefaults"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""DefaultFadeTimeSource"" />
        <Attribute Name=""ValueID"" Type=""Primitive"" ValueType=""String"" Value=""SetInDefaults"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""DefaultFadeDownTimeSource"" />
        <Attribute Name=""ValueID"" Type=""Primitive"" ValueType=""String"" Value=""SetInDefaults"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""DefaultNameSource"" />
        <Attribute Name=""ValueID"" Type=""Primitive"" ValueType=""String"" Value=""SetInDefaults"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""DefaultName"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""String"" Value=""New Cue"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""DefaultTakeFadesSource"" />
        <Attribute Name=""ValueID"" Type=""Primitive"" ValueType=""String"" Value=""SetInDefaults"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""DefaultTakeFades"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""False"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""DefaultTriggerSource"" />
        <Attribute Name=""ValueID"" Type=""Primitive"" ValueType=""String"" Value=""SetInDefaults"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""DefaultTrigger"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""String"" Value=""manual"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""DefaultTriggerValue"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""String"" Value=""1"" />
      </TreeItem>
    </TreeItem>
    <TreeItem Name=""ProjectDefaultConfiguration"">
      <Attribute Name=""ID"" Type=""Primitive"" ValueType=""String"" Value=""c46e6d7b-1cdb-4074-a068-43231735a0f5"" />
      <Attribute Name=""ParameterableType"" Type=""IResourceSerializer"" SerializerName=""LumosTypeSerializer"">
        <TreeItem Name=""SerializedType"">
          <Attribute Name=""Value"" Type=""Primitive"" ValueType=""String"" Value=""org.dmxc.lumos.Kernel.Timecode.Tracks.TrackConfiguration, Lumos, Version=3.2.496.0, Culture=neutral, PublicKeyToken=null"" />
        </TreeItem>
      </Attribute>
      <Attribute Name=""ZZ_SAVE_INDEX"" Type=""Primitive"" ValueType=""Int32"" Value=""3"" />
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Name"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""String"" Value=""New Track"" />
      </TreeItem>
    </TreeItem>
    <TreeItem Name=""ProjectDefaultConfiguration"">
      <Attribute Name=""ID"" Type=""Primitive"" ValueType=""String"" Value=""fef17380-1991-48a8-8674-623d2e78bd07"" />
      <Attribute Name=""ParameterableType"" Type=""IResourceSerializer"" SerializerName=""LumosTypeSerializer"">
        <TreeItem Name=""SerializedType"">
          <Attribute Name=""Value"" Type=""Primitive"" ValueType=""String"" Value=""org.dmxc.lumos.Kernel.Timecode.TimecodeConfiguration, Lumos, Version=3.2.496.0, Culture=neutral, PublicKeyToken=null"" />
        </TreeItem>
      </Attribute>
      <Attribute Name=""ZZ_SAVE_INDEX"" Type=""Primitive"" ValueType=""Int32"" Value=""4"" />
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""TimecodeName"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""String"" Value=""New Timecode"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""TimecodeTimer"" />
        <Attribute Name=""Value"" Type=""Enum"" ValueType=""org.dmxc.lumos.Kernel.Timecode.ETimecodeTimer, LumosLIB, Version=3.2.496.0, Culture=neutral, PublicKeyToken=null"" Value=""NONE"" />
      </TreeItem>
    </TreeItem>
    <TreeItem Name=""ProjectDefaultConfiguration"">
      <Attribute Name=""ID"" Type=""Primitive"" ValueType=""String"" Value=""1946dfdc-c0e5-4091-861d-ac417c5d8d87"" />
      <Attribute Name=""ParameterableType"" Type=""IResourceSerializer"" SerializerName=""LumosTypeSerializer"">
        <TreeItem Name=""SerializedType"">
          <Attribute Name=""Value"" Type=""Primitive"" ValueType=""String"" Value=""Lumos.GUI.Windows.TimecodePlayer.TimecodePlayerViewConfiguration, Lumos, Version=3.2.496.0, Culture=neutral, PublicKeyToken=null"" />
        </TreeItem>
      </Attribute>
      <Attribute Name=""ZZ_SAVE_INDEX"" Type=""Primitive"" ValueType=""Int32"" Value=""5"" />
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Name"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""String"" Value=""Timecode Player"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Background"" />
        <Attribute Name=""Value"" Type=""XmlSerializer"" ValueType=""LumosLIB.GUI.Windows.PropertyGrid.BackgroundImage, LumosLIB, Version=3.2.496.0, Culture=neutral, PublicKeyToken=null"">
          <BackgroundImage xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
            <Image />
          </BackgroundImage>
        </Attribute>
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Background Layout"" />
        <Attribute Name=""Value"" Type=""Enum"" ValueType=""Lumos.GUI.Windows.TimecodePlayer.EImageLayout, LumosLIB, Version=3.2.496.0, Culture=neutral, PublicKeyToken=null"" Value=""None"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Grid Space"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Double"" Value=""0"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Fore Color"" />
        <Attribute Name=""Value"" Type=""IResourceSerializer"" SerializerName=""LumosTypeSerializer"">
          <TreeItem Name=""SerializedColor"">
            <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Int32"" Value=""-1"" />
          </TreeItem>
        </Attribute>
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Fore Color Selected"" />
        <Attribute Name=""Value"" Type=""IResourceSerializer"" SerializerName=""LumosTypeSerializer"">
          <TreeItem Name=""SerializedColor"">
            <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Int32"" Value=""-1"" />
          </TreeItem>
        </Attribute>
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Back Color"" />
        <Attribute Name=""Value"" Type=""IResourceSerializer"" SerializerName=""LumosTypeSerializer"">
          <TreeItem Name=""SerializedColor"">
            <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Int32"" Value=""-1273423504"" />
          </TreeItem>
        </Attribute>
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Back Color Selected"" />
        <Attribute Name=""Value"" Type=""IResourceSerializer"" SerializerName=""LumosTypeSerializer"">
          <TreeItem Name=""SerializedColor"">
            <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Int32"" Value=""-1769275392"" />
          </TreeItem>
        </Attribute>
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#ShowIconNames"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#ShowIconNumbers"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""False"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#LockIconPosition"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""False"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#ShowIconSelectionNumbers"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#ShowIconIntensity"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""False"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#ShowMenuStrip"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#ShowGrid"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""False"" />
      </TreeItem>
    </TreeItem>
    <TreeItem Name=""ProjectDefaultConfiguration"">
      <Attribute Name=""ID"" Type=""Primitive"" ValueType=""String"" Value=""05ec230e-78b6-4a6c-bc6e-e24e0421069a"" />
      <Attribute Name=""ParameterableType"" Type=""IResourceSerializer"" SerializerName=""LumosTypeSerializer"">
        <TreeItem Name=""SerializedType"">
          <Attribute Name=""Value"" Type=""Primitive"" ValueType=""String"" Value=""Lumos.GUI.Windows.LiveView.LiveViewConfiguration, Lumos, Version=3.2.496.0, Culture=neutral, PublicKeyToken=null"" />
        </TreeItem>
      </Attribute>
      <Attribute Name=""ZZ_SAVE_INDEX"" Type=""Primitive"" ValueType=""Int32"" Value=""6"" />
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Name"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""String"" Value=""Stage View"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Background"" />
        <Attribute Name=""Value"" Type=""XmlSerializer"" ValueType=""LumosLIB.GUI.Windows.PropertyGrid.BackgroundImage, LumosLIB, Version=3.2.496.0, Culture=neutral, PublicKeyToken=null"">
          <BackgroundImage xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
            <Image />
          </BackgroundImage>
        </Attribute>
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Background Layout"" />
        <Attribute Name=""Value"" Type=""Enum"" ValueType=""Lumos.GUI.Windows.LiveView.EImageLayout, LumosLIB, Version=3.2.496.0, Culture=neutral, PublicKeyToken=null"" Value=""None"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Grid Space"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Double"" Value=""16"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Fore Color"" />
        <Attribute Name=""Value"" Type=""IResourceSerializer"" SerializerName=""LumosTypeSerializer"">
          <TreeItem Name=""SerializedColor"">
            <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Int32"" Value=""-1"" />
          </TreeItem>
        </Attribute>
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Fore Color Selected"" />
        <Attribute Name=""Value"" Type=""IResourceSerializer"" SerializerName=""LumosTypeSerializer"">
          <TreeItem Name=""SerializedColor"">
            <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Int32"" Value=""-1"" />
          </TreeItem>
        </Attribute>
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Back Color"" />
        <Attribute Name=""Value"" Type=""IResourceSerializer"" SerializerName=""LumosTypeSerializer"">
          <TreeItem Name=""SerializedColor"">
            <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Int32"" Value=""-1273423504"" />
          </TreeItem>
        </Attribute>
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Back Color Selected"" />
        <Attribute Name=""Value"" Type=""IResourceSerializer"" SerializerName=""LumosTypeSerializer"">
          <TreeItem Name=""SerializedColor"">
            <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Int32"" Value=""-1769275392"" />
          </TreeItem>
        </Attribute>
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Back Color Related Selected"" />
        <Attribute Name=""Value"" Type=""IResourceSerializer"" SerializerName=""LumosTypeSerializer"">
          <TreeItem Name=""SerializedColor"">
            <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Int32"" Value=""-1769246720"" />
          </TreeItem>
        </Attribute>
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#ShowIconNames"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#ShowIconNumbers"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""False"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#LockIconPosition"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""False"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#ShowIconSelectionNumbers"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#ShowIconIntensity"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""False"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#ShowMenuStrip"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""True"" />
      </TreeItem>
      <TreeItem Name=""Parameter"">
        <Attribute Name=""Name"" Type=""Primitive"" ValueType=""String"" Value=""Options#ShowGrid"" />
        <Attribute Name=""Value"" Type=""Primitive"" ValueType=""Boolean"" Value=""False"" />
      </TreeItem>
    </TreeItem>
  </TreeItem>
</ManagedTreeData>";

    private string EXAMPLE_DATA_4 = @"<!DOCTYPE html>
<html>
  <body>
    <h1>My First Heading</h1>
    <p>My first paragraph.</p>
  </body>
</html>
";

    public void Start()
    {
        var root = udonXml.LoadXml(EXAMPLE_DATA_4.ToCharArray());

        if (root == null)
        {
            Debug.Log("ROOT WAS NULL!!");
            return;
        }

        for (var i1 = 0; i1 != udonXml.GetChildNodesCount(root); i1++)
        {
            var level1 = udonXml.GetChildNode(root, i1);
            Debug.Log("name: " + udonXml.GetNodeName(level1) + " children: " + udonXml.GetChildNodesCount(level1));
            for (var i2 = 0; i2 != udonXml.GetChildNodesCount(level1); i2++)
            {
                var level2 = udonXml.GetChildNode(level1, i2);
                Debug.Log("  name: " + udonXml.GetNodeName(level2) + " children: " +
                          udonXml.GetChildNodesCount(level2));
                for (var i3 = 0; i3 != udonXml.GetChildNodesCount(level2); i3++)
                {
                    var level3 = udonXml.GetChildNode(level2, i3);
                    Debug.Log("    name: " + udonXml.GetNodeName(level3) + " children: " +
                              udonXml.GetChildNodesCount(level3) + " value: " + udonXml.GetNodeValue(level3));
                }
            }
        }
    }
}