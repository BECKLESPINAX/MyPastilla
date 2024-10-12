#region [Usings]
using NAudio.Wave;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Threading;
using Microsoft.Win32;
using Megal÷SoftMyPastillaStructure;
#endregion [Usings]

namespace MyPastilla
{
 public partial class Window1 : Window
 {
  private DispatcherTimer timerhora = new DispatcherTimer();
  private DispatcherTimer timerpastilla = new DispatcherTimer();
  private DispatcherTimer timerwarning = new DispatcherTimer();
  private DispatcherTimer timerspeech = new DispatcherTimer();
  private IWavePlayer waveOutDevice;
  private AudioFileReader audioFileReader;
  private SpeechSynthesizer speechsynthesizer;
  private bool btimerwarning = false;
  private int itimercount = 1;
  private bool bisexect = false;
  public List<StructPastilla> ListPastilla = new List<StructPastilla>();
  private List<int> ListProhibidos = new List<int>();
  private List<StructPastilla> ListPastillaEspera = new List<StructPastilla>();
  private ClassPerson clperson = new ClassPerson();
  private ClassProperty clproperty = new ClassProperty();
  private ClassPastilla clpastilla = new ClassPastilla();
  private MediaElement mediamusic = new MediaElement();
  private StructProperty stproperty = default(StructProperty);
  private StructPerson stperson = default(StructPerson);
  private int ubic = -1;
  private NotifyIcon iconoNotificacion;
  private System.Windows.Forms.ContextMenu menu = new System.Windows.Forms.ContextMenu();
//  private bool _contentLoaded;
  public Window1()
 {

 this.InitializeComponent();
 this.vSetTimerHour();
  this.vSetTimerPastilla();
  this.vSetTimerWarning();
  this.vSetProperty();
  this.vSetPerson();
  this.vSetListPastillas();
  this.vSetNotifyIcon();
  this.vSetContextMenuToNotifyIcon();
  this.vSiUsarMas();

}
  private void vSetTimerHour()
  {
  this.timerhora.Tick += new EventHandler(this.dispatcherTimer_Tick);
  this.timerhora.Interval = new TimeSpan(0, 0, 1);
  this.timerhora.Start();
  }
  private void vSetPerson()
  {
  this.clperson.bShow(ref this.stperson);
  }
private void vSetTimerPastilla()
{
this.timerpastilla.Tick += new EventHandler(this.dispatcherTimer_pastilla_Tick);
this.timerpastilla.Interval = new TimeSpan(0, 0, 7);
this.timerpastilla.Start();
}


private void vSetTimerWarning()
{
this.timerwarning.Tick += new EventHandler(this.dispatcherTimer_warning_Tick);
this.timerwarning.Interval = new TimeSpan(0, 0, 1);
}


private void vSetTimerSpeech()
{
}


private void vSetProperty()
{
this.clproperty.bShow(ref this.stproperty);
}

private void vSetListPastillas()
{
this.ubic = -1;
this.clpastilla.bShowList(ref this.ListPastilla);
}

private void dispatcherTimer_Tick(object sender, EventArgs e)
{
try{
this.LabelHour.Content = DateTime.Now.ToLongTimeString();
}catch{}

}

private void dispatcherTimer_warning_Tick(object sender, EventArgs e)
{
if (this.btimerwarning)
{
this.LabelPastilla.Visibility = Visibility.Collapsed;
this.btimerwarning = false;
}
else
{
this.LabelPastilla.Visibility = Visibility.Visible;
this.btimerwarning = true;
}
}


private void dispatcherTimer_pastilla_Tick(object sender, EventArgs e)
{
try{

checked
{
for (int i = 0; i < this.ListPastilla.Count; i++)
{
if (this.clpastilla.WarningPastilla(ref this.ListPastilla, i))
{
StructPastilla stpas = default(StructPastilla);
stpas = this.ListPastilla[i];
stpas.bya_aviso = true;
this.ListPastilla[i] = stpas;
this.ubic = i;
this.vPlayWarning();
this.vPlayMusic();
this.vPlaySpeech();
}
}
}
}catch{}
}


private void ClickConfiguration(object sender, RoutedEventArgs e)
{
new WindowConfiguration().ShowDialog();
this.vSetListPastillas();
}


private void ClickNotUserMore(object sender, RoutedEventArgs e)
{
string messageBoxText = "La aplicaciÛn dejar· de iniciarse con Windows.\n" +
				"Desea verdaderamente no usar m·s esta aplicaciÛn?";
string caption = "Seguramente sos Raza Puta";
System.Windows.MessageBoxButton button = System.Windows.MessageBoxButton.YesNo;
System.Windows.MessageBoxImage icon = System.Windows.MessageBoxImage.Exclamation;
System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);
if(result==System.Windows.MessageBoxResult.Yes)
{
//Reformo la clave
vNoUsarMas();
this.Close();
}

}

private void ClickExit(object sender, RoutedEventArgs e)
{
base.WindowState = WindowState.Minimized;
}

private void ClickOk(object sender, RoutedEventArgs e)
{
this.vStopMusic();
this.vStopSpeech();
this.vStopWarning();
this.ListProhibidos.Add(this.ubic);
this.bisexect = false;
this.ubic = -1;
}

private void ClickProperty(object sender, RoutedEventArgs e)
{
new WindowProperty().ShowDialog();
this.vSetProperty();
}

private void ClickAbout(object sender, RoutedEventArgs e)
{
new WindowAbout().ShowDialog();
}

private void vPlayWarning()
{
this.LabelPastilla.Content = this.ListPastilla[this.ubic].sdescription;
this.timerwarning.Stop();
this.timerwarning.Start();
}

private void vPlayMusic()
{
if (this.stproperty.bsound)
{
try
{
this.waveOutDevice.Stop();
}
catch
{
}
this.waveOutDevice = new WaveOut();
if(this.stproperty.subication_sound=="")
{
this.stproperty.subication_sound="MARCHAUNI”N.mp3";
}
this.audioFileReader = new AudioFileReader(this.stproperty.subication_sound);
this.waveOutDevice.Init(this.audioFileReader);
this.waveOutDevice.Play();
}
}

private void vPlaySpeech()
{
Thread threadspeech = new Thread(new ThreadStart(this.vShowSpeech));
threadspeech.Start();
}


private void vShowSpeech()
{
/*Dispatcher.Invoke(DispatcherPriority.Background, checked(
delegate
{*/
if (this.stproperty.bspeech && this.ubic > -1)
{
for (int i = 0; i < (int)this.stproperty.i16repetition_speech; i++)
{
this.speechsynthesizer = new SpeechSynthesizer();
string sspeech = this.stperson.sname + "...  " + this.ListPastilla[this.ubic].sdescription;
if (this.stproperty.bspeech_tomar_pastilla)
{
sspeech = this.stperson.sname + "...  tomar pastilla...  " + this.ListPastilla[this.ubic].sdescription;
}
this.speechsynthesizer.Speak(sspeech);
}
}
//}));
}


private void vStopMusic()
{
this.waveOutDevice.Stop();
}


private void vStopSpeech()
{
this.waveOutDevice.Stop();
}

private void vStopWarning()
{
this.timerwarning.Stop();
}


private void ClickHelp(object sender, RoutedEventArgs e)
{
new WindowHelp("HelpMiPastilla").ShowDialog();
}

private void item1_Click(object sender, EventArgs e)
{
base.Show();
base.WindowState = WindowState.Normal;
}

private void item2_Click(object sender, EventArgs e)
{
new WindowAbout().ShowDialog();
}
private void item3_Click(object sender, EventArgs e)
{
vNoUsarMas();
this.Close();
}
private void item4_Click(object sender, EventArgs e)
{
base.Close();
}


void vSiUsarMas()
{
RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
rkApp.SetValue("MyPastilla", System.Windows.Forms.Application.ExecutablePath.ToString());
//rkApp.CreateSubKey("MyPastilla");
}

void vNoUsarMas()
{
RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
rkApp.DeleteValue("MyPastilla");
}





private void vSetNotifyIcon()
{
this.iconoNotificacion = new NotifyIcon();
this.iconoNotificacion.BalloonTipText = "MyPastilla se est· ejecutando...";
this.iconoNotificacion.BalloonTipTitle = "MyPastilla";
this.iconoNotificacion.Text = "Realice Click para Mostrar";
this.iconoNotificacion.Icon = new Icon("MyPastillaIco.ico");
this.iconoNotificacion.BalloonTipIcon = ToolTipIcon.Info;
this.iconoNotificacion.Click += new EventHandler(this.iconoNotificacion_Click);
}

private void vSetContextMenuToNotifyIcon()
{
System.Windows.Forms.MenuItem item = new System.Windows.Forms.MenuItem("Mostrar");
item.Click += new EventHandler(this.item1_Click);
System.Windows.Forms.MenuItem item2 = new System.Windows.Forms.MenuItem("Acerca de...");
item2.Click += new EventHandler(this.item2_Click);
System.Windows.Forms.MenuItem item3 = new System.Windows.Forms.MenuItem("No usar m·s");
item3.Click += new EventHandler(this.item3_Click);

System.Windows.Forms.MenuItem item4 = new System.Windows.Forms.MenuItem("Salir");
item4.Click += new EventHandler(this.item4_Click);

this.menu.MenuItems.Add(item);
this.menu.MenuItems.Add(item2);
this.menu.MenuItems.Add(item3);
this.menu.MenuItems.Add(item4);
this.iconoNotificacion.ContextMenu = this.menu;
}
private void iconoNotificacion_Click(object sender, EventArgs e)
{
base.Show();
base.WindowState = WindowState.Normal;
}
private void Window_StateChanged(object sender, EventArgs e)
{
if (base.WindowState == WindowState.Minimized)
{
base.Hide();
if (this.iconoNotificacion != null)
{
this.iconoNotificacion.ShowBalloonTip(2000);
}
}
}

private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
{
this.VerificarIcono();
}

private void VerificarIcono()
{
this.MostrarIcono(!base.IsVisible);
}

private void MostrarIcono(bool mostrar)
{
if (this.iconoNotificacion != null)
{
this.iconoNotificacion.Visible = mostrar;
}
}


   }//End class
}//End namespace
