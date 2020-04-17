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

    private string EXAMPLE_DATA_5 = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<w:document xmlns:w=""http://schemas.openxmlformats.org/wordprocessingml/2006/main"" xmlns:m=""http://schemas.openxmlformats.org/officeDocument/2006/math"" xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006"" xmlns:o=""urn:schemas-microsoft-com:office:office"" xmlns:r=""http://schemas.openxmlformats.org/officeDocument/2006/relationships"" xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:w10=""urn:schemas-microsoft-com:office:word"" xmlns:w14=""http://schemas.microsoft.com/office/word/2010/wordml"" xmlns:w15=""http://schemas.microsoft.com/office/word/2012/wordml"" xmlns:wne=""http://schemas.microsoft.com/office/word/2006/wordml"" xmlns:wp=""http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing"" xmlns:wp14=""http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing"" xmlns:wpc=""http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas"" xmlns:wpg=""http://schemas.microsoft.com/office/word/2010/wordprocessingGroup"" xmlns:wpi=""http://schemas.microsoft.com/office/word/2010/wordprocessingInk"" xmlns:wps=""http://schemas.microsoft.com/office/word/2010/wordprocessingShape"" xmlns:wpsCustomData=""http://www.wps.cn/officeDocument/2013/wpsCustomData"" mc:Ignorable=""w14 w15 wp14"">
   <w:body>
      <w:p>
         <w:pPr>
            <w:rPr>
               <w:rFonts w:hint=""default"" />
               <w:lang w:val=""sv-SE"" />
            </w:rPr>
         </w:pPr>
         <w:r>
            <w:rPr>
               <w:rFonts w:hint=""default"" />
               <w:lang w:val=""sv-SE"" />
            </w:rPr>
            <w:t>Hello worlds.</w:t>
         </w:r>
         <w:bookmarkStart w:id=""0"" w:name=""_GoBack"" />
         <w:bookmarkEnd w:id=""0"" />
      </w:p>
      <w:sectPr>
         <w:pgSz w:w=""11906"" w:h=""16838"" />
         <w:pgMar w:top=""1440"" w:right=""1800"" w:bottom=""1440"" w:left=""1800"" w:header=""720"" w:footer=""720"" w:gutter=""0"" />
         <w:cols w:space=""720"" w:num=""1"" />
         <w:docGrid w:linePitch=""360"" w:charSpace=""0"" />
      </w:sectPr>
   </w:body>
</w:document>";

    private string EXAMPLE_DATA_6 = @"<!doctype html >
<html>
<head>
    <title>Example Domain</title>

    <meta charset=""utf-8"" />
    <meta http-equiv=""Content-type"" content=""text/html; charset=utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"" />
    <style type=""text/css"">
    body {
        background-color: #f0f0f2;
        margin: 0;
        padding: 0;
        font-family: -apple-system, system-ui, BlinkMacSystemFont, ""Segoe UI"", ""Open Sans"", ""Helvetica Neue"", Helvetica, Arial, sans-serif;
        
    }
    div {
        width: 600px;
        margin: 5em auto;
        padding: 2em;
        background-color: #fdfdff;
        border-radius: 0.5em;
        box-shadow: 2px 3px 7px 2px rgba(0,0,0,0.02);
    }
    a:link, a:visited {
        color: #38488f;
        text-decoration: none;
    }
    @media (max-width: 700px) {
        div {
            margin: 0 auto;
            width: auto;
        }
    }
    </style>    
</head>

<body>
<div>
    <h1>Example Domain</h1>
    <p>This domain is for use in illustrative examples in documents. You may use this
    domain in literature without prior coordination or asking for permission.</p>
    <p><a href=""https://www.iana.org/domains/example"">More information...</a></p>
</div>
</body>
</html>
";

    private string EXAMPLE_DATA_7 = @"<!DOCTYPE html>
<html lang=""en"">
	<head>
		<title>Free Online HTML Formatter - FreeFormatter.com</title>
		<meta name=""title"" content=""Free Online HTML Formatter - FreeFormatter.com""/>
		<meta name=""description"" content=""This free online HTML formatter and validator lets you chose your indentation level and also lets you export to file""/>
		<meta name=""language"" content=""en""/>
		<meta name=""robots"" content=""all""/>
		<meta name=""rating"" content=""general""/>
		<meta charset=""utf-8""/>
		<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8""/>
		<link rel=""shortcut icon"" href=""favicon.ico""/>
		<link rel=""stylesheet"" href=""/3.4.0.3/css/styles.css""/>
		<link rel=""stylesheet"" href=""//ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/cupertino/jquery-ui.css""/>
		<script src=""//ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js""></script>
		<script src=""//ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/jquery-ui.min.js""></script>
		<script src=""/3.4.0.3/js/freeformatter.js""></script>
		<link rel=""stylesheet"" href=""//cdnjs.cloudflare.com/ajax/libs/highlight.js/9.6.0/styles/vs.min.css"">
			<script src=""//cdnjs.cloudflare.com/ajax/libs/highlight.js/9.6.0/highlight.min.js""></script>
			<script>hljs.initHighlightingOnLoad();</script>
			<script type=""text/javascript"">
		
		$(function() {
			$('#selectAll').click(FF.selectOutput);
			new Clipboard('#copyToClipboard');
		});
		
		var FF =  {
				
			submit: function(usenewwindow) {

				if (!_assertFileSize('#htmlFile')) {
					return false;
				}
				
				$('#forceInNewWindow').val(usenewwindow);
				
				if (usenewwindow) {
					$('#form').attr('target', '_blank');
				} else {
					$('#form').attr('target', '_self');
				}
				
				$('#form').trigger('submit');
				
			}, selectOutput: function() {
				
				var text = $('#htmlOutput')[0];
				
				if ($.browser.msie) {
					var range = document.body.createTextRange();
					range.moveToElementText(text);
					range.select();
				} else {
					var selection = window.getSelection();
					var range = document.createRange();
					range.selectNodeContents(text);
					selection.removeAllRanges();
					selection.addRange(range);
				}
				
			}
			
		}
		
	</script>
		</head>
		<body>
			<div class=""topbar"">
				<div class=""topbar-inner"">
					<div class=""container-fluid"">
						<a class=""brand"" href=""http://www.freeformatter.com"">FreeFormatter.com</a>
						<ul class=""nav"">
							<li>
								<a href=""https://www.freeformatter.com"">HTTPS</a>
							</li>
							<li>
								<a href=""mailto:freeformatter@gmail.com"">Contact</a>
							</li>
						</ul>
						<div class=""social"" style=""float:right;"">
							<div class=""fb-like"" data-href=""http://www.freeformatter.com"" data-send=""false"" data-layout=""button_count"" data-width=""50"" data-show-faces=""true"" data-font=""arial""></div>
							<!-- Place this tag where you want the +1 button to render -->
							<div style=""float: left; padding: 8px 5px 5px;"">
								<g:plusone></g:plusone>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class=""container-fluid"">
				<div class=""sidebar"">
					<div class=""well"">
						<a href=""/formatters.html"">
							<h5>Formatters</h5>
						</a>
						<ul>
							<li>
								<a href=""/json-formatter.html"">JSON Formatter</a>
							</li>
							<li>
								<a href=""/html-formatter.html"">HTML Formatter</a>
							</li>
							<li>
								<a href=""/xml-formatter.html"">XML Formatter</a>
							</li>
							<li>
								<a href=""/sql-formatter.html"">SQL Formatter</a>
							</li>
							<li>
								<a href=""/batch-formatter.html"">Batch Formatter (new!)
							</a>
						</li>
					</ul>
					<a href=""/validators.html"">
						<h5>Validators</h5>
					</a>
					<ul>
						<li>
							<a href=""/json-validator.html"">JSON Validator</a>
						</li>
						<li>
							<a href=""/html-validator.html"">HTML Validator</a>
						</li>
						<li>
							<a href=""/xml-validator-xsd.html"">XML Validator - XSD</a>
						</li>
						<li>
							<a href=""/xpath-tester.html"">XPath Tester</a>
						</li>
						<li>
							<a href=""/credit-card-number-generator-validator.html"">Credit Card Number Generator & Validator</a>
						</li>
						<li>
							<a href=""/regex-tester.html"">Regular Expression Tester</a>
						</li>
						<li>
							<a href=""/java-regex-tester.html"">Java Regular Expression Tester</a>
						</li>
						<li>
							<a href=""/cron-expression-generator-quartz.html"">Cron Expression Generator - Quartz</a>
						</li>
					</ul>
					<a href=""/encoders.html"">
						<h5>Encoders & Decoders</h5>
					</a>
					<ul>
						<li>
							<a href=""/url-encoder.html"">Url Encoder & Decoder</a>
						</li>
						<li>
							<a href=""/base64-encoder.html"">Base 64 Encoder & Decoder</a>
						</li>
						<li>
							<a href=""/qr-code-generator.html"">QR Code Generator</a>
						</li>
					</ul>
					<a href=""/minifiers.html"">
						<h5>Code Minifiers / Beautifier</h5>
					</a>
					<ul>
						<li>
							<a href=""/javascript-beautifier.html"">JavaScript Beautifier</a>
						</li>
						<li>
							<a href=""/css-beautifier.html"">CSS Beautifier</a>
						</li>
						<li>
							<a href=""/javascript-minifier.html"">JavaScript Minifier</a>
						</li>
						<li>
							<a href=""/css-minifier.html"">CSS Minifier</a>
						</li>
					</ul>
					<a href=""/converters.html"">
						<h5>Converters</h5>
					</a>
					<ul>
						<li>
							<a href=""/xsd-generator.html"">XSD Generator</a>
						</li>
						<li>
							<a href=""/xsl-transformer.html"">XSLT (XSL Transformer)</a>
						</li>
						<li>
							<a href=""/xml-to-json-converter.html"">XML to JSON Converter</a>
						</li>
						<li>
							<a href=""/json-to-xml-converter.html"">JSON to XML Converter</a>
						</li>
						<li>
							<a href=""/csv-to-xml-converter.html"">CSV to XML Converter</a>
						</li>
						<li>
							<a href=""/csv-to-json-converter.html"">CSV to JSON Converter</a>
						</li>
						<li>
							<a href=""/epoch-timestamp-to-date-converter.html"">Epoch Timestamp To Date</a>
						</li>
					</ul>
					<a href=""/cryptography-and-security.html"">
						<h5>Cryptography & Security</h5>
					</a>
					<ul>
						<li>
							<a href=""/message-digest.html"">Message Digester (MD5, SHA-256, SHA-512)</a>
						</li>
						<li>
							<a href=""/hmac-generator.html"">HMAC Generator</a>
						</li>
						<li>
							<a href=""/md5-generator.html"">MD5 Generator</a>
						</li>
						<li>
							<a href=""/sha256-generator.html"">SHA-256 Generator</a>
						</li>
						<li>
							<a href=""/sha512-generator.html"">SHA-512 Generator</a>
						</li>
					</ul>
					<a href=""/string-escaper.html"">
						<h5>String Escaper & Utilities</h5>
					</a>
					<ul>
						<li>
							<a href=""/string-utilities.html"">String Utilities</a>
						</li>
						<li>
							<a href=""/html-escape.html"">HTML Escape</a>
						</li>
						<li>
							<a href=""/xml-escape.html"">XML Escape</a>
						</li>
						<li>
							<a href=""/java-dotnet-escape.html"">Java and .Net Escape</a>
						</li>
						<li>
							<a href=""/javascript-escape.html"">JavaScript Escape</a>
						</li>
						<li>
							<a href=""/json-escape.html"">JSON Escape</a>
						</li>
						<li>
							<a href=""/csv-escape.html"">CSV Escape</a>
						</li>
						<li>
							<a href=""/sql-escape.html"">SQL	Escape</a>
						</li>
					</ul>
					<a href=""/web-resources.html"">
						<h5>Web Resources</h5>
					</a>
					<ul>
						<li>
							<a href=""/lorem-ipsum-generator.html"">Lorem Ipsum Generator</a>
						</li>
						<li>
							<a href=""/less-compiler.html"">LESS Compiler</a>
						</li>
						<li>
							<a href=""/mime-types-list.html"">List of MIME types</a>
						</li>
						<li>
							<a href=""/html-entities.html"">HTML Entities</a>
						</li>
						<li>
							<a href=""/url-parser-query-string-splitter.html"">Url Parser / Query String Splitter</a>
						</li>
						<li>
							<a href=""/i18n-standards-code-snippets.html"">i18n - Formatting standards & code snippets</a>
						</li>
						<li>
							<a href=""/iso-country-list-html-select.html"">ISO country list - HTML select snippet</a>
						</li>
						<li>
							<a href=""/usa-state-list-html-select.html"">USA state list - HTML select snippet</a>
						</li>
						<li>
							<a href=""/canada-province-list-html-select.html"">Canada province	list - HTML select snippet</a>
						</li>
						<li>
							<a href=""/mexico-state-list-html-select.html"">Mexico state list - HTML select snippet</a>
						</li>
						<li>
							<a href=""/time-zone-list-html-select.html"">Time zone list - HTML select snippet</a>
						</li>
					</ul>
				</div>
				<div style=""text-align: center;"">
					<script async src=""//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js""></script>
					<!-- freeformatter-responsive -->
					<ins class=""adsbygoogle""
     style=""display:block""
     data-ad-client=""ca-pub-2485708030241382""
     data-ad-slot=""9677864628""
     data-ad-format=""auto""></ins>
					<script>
(adsbygoogle = window.adsbygoogle || []).push({});
</script>
				</div>
			</div>
			<div class=""content"">
				<div class=""content-inner"">
					<h1>HTML Formatter</h1>
					<p>
					Formats a HTML string/file with your desired indentation level. The formatting rules are not configurable but are already optimized for the best possible output. 
				</p>
					<p>
					Note that the formatter will keep spaces and tabs between content tags such as div and span as it's considered to be valid content.
				</p>
					<p>
						<strong>*The maximum size limit for file upload is 2 megabytes. All files bigger than 500k will be formatted to a new window for performance reason and to prevent your browser from being unresponsive.</strong>
					</p>
					<div id=""notifications""></div>
					<div class=""form-wrapper"">
						<form id=""form"" action=""https://www.freeformatter.com/html-formatter.html"" method=""POST"" enctype=""multipart/form-data"">
							<input id=""forceInNewWindow"" name=""forceInNewWindow"" type=""hidden"" value=""false""/>
							<div class=""title first"">
								<span class=""option"">Option 1:</span>
								<span class=""option-text"">Copy-paste your HTML document here</span>
							</div>
							<textarea id=""htmlString"" name=""htmlString""></textarea>
							<div class=""title"">
								<span class=""option"">Option 2:</span>
								<span class=""option-text"">Or upload your HTML document</span>
							</div>
							<input type=""file"" id=""htmlFile"" name=""htmlFile"" style=""width:60%;display:inline;""/>
							<select id=""encoding"" name=""encoding"" style=""width:30%;display:inline;"">
								<option value=""ISO-8859-1"">ISO-8859-1 (Latin Alphabet No. 1)</option>
								<option value=""ISO-8859-2"">ISO-8859-2 (Latin Alphabet No. 2)</option>
								<option value=""ISO-8859-3"">ISO-8859-3 (Latin Alphabet No. 3)</option>
								<option value=""ISO-8859-4"">ISO-8859-4 (Latin Alphabet No. 4)</option>
								<option value=""ISO-8859-5"">ISO-8859-5 (Latin/Cyrillic Alphabet)</option>
								<option value=""ISO-8859-6"">ISO-8859-6 (Latin/Arabic Alphabet)</option>
								<option value=""ISO-8859-7"">ISO-8859-7 (Latin/Greek Alphabet)</option>
								<option value=""ISO-8859-8"">ISO-8859-8 (Latin/Hebrew Alphabet)</option>
								<option value=""ISO-8859-9"">ISO-8859-9 (Latin Alphabet No. 5)</option>
								<option value=""ISO-8859-13"">ISO-8859-13 (Latin Alphabet No. 7)</option>
								<option value=""ISO-8859-15"">ISO-8859-15 (Latin Alphabet No. 9)</option>
								<option value=""UTF-8"" selected=""selected"">UTF-8</option>
								<option value=""UTF-16"">UTF-16</option>
								<option value=""UTF-16BE"">UTF-16 (Big-Endian)</option>
								<option value=""UTF-16LE"">UTF-16 (Little-Endian)</option>
								<option value=""UTF-32"">UTF-32</option>
								<option value=""UTF-32BE"">UTF-32 (Big-Endian)</option>
								<option value=""UTF-32LE"">UTF-32 (Little-Endian)</option>
								<option value=""US-ASCII"">US-ASCII</option>
								<option value=""windows-1250"">windows-1250 (Windows Eastern European)</option>
								<option value=""windows-1251"">windows-1251 (Windows Cyrillic)</option>
								<option value=""windows-1252"">windows-1252 (Windows Latin-1)</option>
								<option value=""windows-1253"">windows-1253 (Windows Greek)</option>
								<option value=""windows-1254"">windows-1254 (Windows Turkish)</option>
								<option value=""windows-1255"">windows-1255 (Windows Hebrew)</option>
								<option value=""windows-1256"">windows-1256 (Windows Arabic)</option>
								<option value=""windows-1257"">windows-1257 (Windows Baltic)</option>
								<option value=""windows-1258"">windows-1257 (Windows Vietnamese)</option>
							</select>
							<div class=""title"">
								<span class=""option"">Indentation level:</span>
							</div>
							<select id=""indentation"" name=""indentation"">
								<option value=""TWO_SPACES"">2 spaces per indent level</option>
								<option value=""THREE_SPACES"" selected=""selected"">3 spaces per indent level</option>
								<option value=""FOUR_SPACES"">4 spaces per indent level</option>
								<option value=""TABS"">Tab delimited</option>
`						
							</select>
							<div class=""buttons"">
								<button class=""btn primary"" title=""Format the HTML document"" onclick=""FF.submit(false);return false;"">FORMAT HTML</button>
								<button class=""btn primary"" title=""Format the HTML document in new window"" onclick=""FF.submit(true);return false;"">FORMAT HTML IN NEW WINDOW</button>
							</div>
							<div></div>
						</form>
					</div>
					<div id=""ad-output"" class=""ad-wrapper"">
						<script async src=""//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js""></script>
						<!-- freeformatter-responsive -->
						<ins class=""adsbygoogle""
     style=""display:block""
     data-ad-client=""ca-pub-2485708030241382""
     data-ad-slot=""9677864628""
     data-ad-format=""auto""></ins>
						<script>
(adsbygoogle = window.adsbygoogle || []).push({});
</script>
					</div>
				</div>
				<footer>
					<p>&copy; FreeFormatter.com - FREEFORMATTER is a d/b/a of 10174785 Canada Inc. - 
						<a href=""/copyright-notice.html"">Copyright Notice</a> - 
						<a href=""/privacy-statement.html"">Privacy Statement</a> - 
						<a href=""/terms-of-use.html"">Terms of Use</a>
					</p>
				</footer>
			</div>
		</div>
		<script type=""text/javascript"">
  var _gaq = _gaq || [];
  _gaq.push(['_setAccount', 'UA-24060392-1']);
  _gaq.push(['_trackPageview']);
  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
  })();
</script>
		<div id=""fb-root""></div>
		<script>
	(
		function() {
    		var e = document.createElement('script'); e.async = true;
    		e.setAttribute('defer', 'defer');
    		e.src = document.location.protocol + '//connect.facebook.net/en_US/all.js#xfbml=1';    		
    		document.getElementById('fb-root').appendChild(e);
 		}()
 	);
</script>
		<script type=""text/javascript"">
	$(document).ready(function() {		
		$('body').append('
			<scri' + 'pt type=""text/javascript"" src=""//apis.google.com/js/plusone.js"" defer>
			</scr' + 'ipt>');		
	});	

		</script>
	</body>
</html>";

    public void Start()
    {
        var root = udonXml.LoadXml(EXAMPLE_DATA_7);

        if (root == null)
        {
            Debug.Log("ROOT WAS NULL!!");
            return;
        }

        /*for (var i1 = 0; i1 != udonXml.GetChildNodesCount(root); i1++)
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
        }*/

        Debug.Log(udonXml.SaveXmlWithIdent(root, "	"));
    }
}