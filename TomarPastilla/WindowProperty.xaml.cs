/*
 * Creado por SharpDevelop.
 * MegalÖSoft
 * Fecha: 03/22/2014
 * Hora: 19:46
 * 
 */

#region [Usings]
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using System.IO;
using MegalÖSoftMyPastillaStructure;
#endregion [Usings]

namespace MyPastilla
{
/// <summary>
/// Interaction logic for WindowProperty.xaml
/// </summary>
public partial class WindowProperty : Window
{
#region [Globals]
ClassProperty clproperty=new ClassProperty();
StructProperty stproperty=new StructProperty();
#endregion [Globals]

public WindowProperty()
{
InitializeComponent();
vSet();
}
		
void ClickExit(object sender, RoutedEventArgs e)
{
this.Close();
}
void ClickSelectSong(object sender, RoutedEventArgs e)
{
OpenFileDialog openFileDialog1 = new OpenFileDialog(); 

openFileDialog1.Filter = "Archivos de música (.mp3)|*.mp3|All Files (*.*)|*.*"; 
openFileDialog1.FilterIndex = 1; 

openFileDialog1.Multiselect = false; 

bool? checarOK = openFileDialog1.ShowDialog(); 

if (checarOK==true)
{
string s = @openFileDialog1.FileName;

stproperty.subication_sound =s;
RichTextBoxUbicationSound.Document.Blocks.Clear();
RichTextBoxUbicationSound.Document.Blocks.Add(new Paragraph(new Run(s)));


string ss=System.AppDomain.CurrentDomain.BaseDirectory;
Directory.SetCurrentDirectory(ss);

//String exePath = System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
//string dir = Path.GetDirectoryName(exePath);


}


}
void ClickSave(object sender, RoutedEventArgs e)
{
stproperty.i16repetition_speech=ShortUpDownRepeat.Value.Value;
stproperty.i16duration_warning=ShortUpDownDurationWarning.Value.Value;
stproperty.bsound=CheckBoxSound.IsChecked.Value;
stproperty.bspeech=CheckBoxSpeech.IsChecked.Value;
stproperty.bspeech_tomar_pastilla=CheckBoxTomarPastilla.IsChecked.Value;
//stproperty.subication_sound = new TextRange(RichTextBoxUbicationSound.Document.ContentStart, RichTextBoxUbicationSound.Document.ContentEnd).Text;
//MessageBox.Show(stproperty.bspeech_tomar_pastilla.ToString());

if(clproperty.bUpdate(stproperty))
{
MessageBox.Show("Se ha actualizado correctamente las propiedades.");
}
else
 MessageBox.Show("Hubo un error.");

}



void vSet()
{
if (clproperty.bShow(ref stproperty))
{
ShortUpDownRepeat.Value=stproperty.i16repetition_speech;
ShortUpDownDurationWarning.Value=stproperty.i16duration_warning;
CheckBoxSound.IsChecked=stproperty.bsound;
CheckBoxSpeech.IsChecked=stproperty.bspeech;
CheckBoxTomarPastilla.IsChecked=stproperty.bspeech_tomar_pastilla;

RichTextBoxUbicationSound.Document.Blocks.Clear();
RichTextBoxUbicationSound.Document.Blocks.Add(new Paragraph(new Run(stproperty.subication_sound)));
}

}

		
void ClickHelp(object sender, RoutedEventArgs e)
{
new WindowHelp("HelpProperty").ShowDialog();
}
	}//End class
}//End namespace