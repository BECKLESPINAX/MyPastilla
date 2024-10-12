/*
 * Creado por SharpDevelop.
 * MegalÖSoft
 * Fecha: 03/27/2014
 * Hora: 23:22
 * 
 */

#region {Usings}
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
#endregion {Usings}


namespace MyPastilla
{
/// <summary>
/// Interaction logic for WindowHelp.xaml
/// </summary>
public partial class WindowHelp : Window
{
#region {Globals}
string stext="";
#endregion {Globals}

public WindowHelp()
{
InitializeComponent();
}

public WindowHelp(string shelp)
{
InitializeComponent();


if(shelp=="HelpConfiguration")
vSetHelpConfiguration();

if(shelp=="HelpMiPastilla")
vSetHelpMiPastilla();

if(shelp=="HelpProperty")
vSetHelpProperty();

RichTextBoxHelp.Document.Blocks.Add(new Paragraph(new Run(stext)));
	
}


void vSetHelpConfiguration()
{
stext="Ayuda de MyPatilla...\n"+
" En esta ventana se colocan las pastillas que debemos tomar.\n"+
" Sólo se puede colcar una pastilla por hora y minuto, es decir, que si se quieren colocar 2 pastillas, "+
"nos dará error.\n"+
" Si son 2 las pastillas que deben tomarse en el mismo horario, colocar las 2 juntas en la misma fila, por ejemplo:\n"+
" Juan tiene que tomar Bayaspirina y Natividad una píldora de cianuro.\n\n\n"+

" Botón Agregar: Este botón sirve para agregar una pastilla.\n"+
" Botón Actualizar: Actualiza la pastilla. Descripción y Fecha.\n" +
" Botón Eliminar: Elimina una pastilla, previamente debe seleccionarla en la grilla.\n";
}

void vSetHelpMiPastilla()
{
stext = "Ayuda de MyPatilla...\n" +
" El sistema está pensado para satisfacer mi necesidad sin importar la problemática del resto.\n" +
" Acepto alguna sugerencia, pero reitero, el sistema fue pensado para mí.\n" +
" Nace por mis olvidos permanentes de tomar la Pastilla!!! Maldita!!! para la Hipertiroides llamada Metimazol de 5 mg, " +
"que me dió la doctora Camacho, la cuál debo tomar 2 veces al día, una entera primero y media después. Antes eran 2 enteras diarias.\n"+
" Si le sirve a alguien, bien, y si no mejor, no se aceptan quejas por mal funcionamiento!!!\n\n\n" +


" Botón \"Pastillas\": Este botón sirve para agregar una pastilla. Despliega una Ventana en la cuál podrán hacerse los cambios pertinentes sobres las pastillas a tomar.\n" +
" Botón \"Propiedades\": Despliega las propiedades del sistema, donde se podrán cambiar cosas como por ejemplo el tema a esuchar en la alerta.\n" +
" Botón \"Ya la Tomé\": Dictamina que una pastilla ya fue tomada y detiene el proceso de aviso y alerta.\n\n"+


" Cómo empezar: \n"+
" Lo primero que debe hacer es presionar en el botón \"Propiedades\", allí elija las opciones detalladas.\n"+
" Tilde la casilla de la  música si quiere que reproduzca un sonido, tilde la casilla para que la computadora le hable, elija la cantidad de repeticiones si así lo desea. "+
" Puede elegir además la duración del alerta.\n"+
" Una vez configurados estos parámetros salga de esta ventana y luego presione el botón \"Pastillas\", allí deberá ingresar las pastillas que debe tomar en forma diaria con su hora cada una. "+
" Si tiene que tomar dos pastillas en distintas horas, ingrésela 2 veces con sus distintos horarios, si tiene que tomar varias pastillas a la misma hora, ingrese una vez como se indica en la ayuda de la ventana \"Pastillas\"."+

"\n\n\n" +
" Cosas para agregar o mejorar en futuras versiones ¿Quizás nunca?:\n"+
"- Un histórico de pastillas no tomadas.\n"+
"- Una mejor interfaz de usuario.\n"+
"- Versión para celulares.";
}
void vSetHelpProperty()
{
stext = "Ayuda de MyPatilla...\n" +
" Aquí se pueden cambiar ciertos parámetros con respecto al funcionamiento del sistema.\n" +


" Emitir el siguiente sonido o música: Si tilda esta casilla sonará algún tema o sonido que usted puede elegir" +
" presionando en el botón \"Seleccionar\".\n"+
" Aviso hablado de la computadra: Esta opción permite acceder a una característica única, donde la computadora le hablará y le dirá qué pastilla debe tomar."+
" Cabe mencionar que el sistema utiliza el motor de voz de cada Sistema Operativo, si el Sistema Operativo está en inglés o el núcleo está en inglés (aunque traducido), el sistema le hablará en inglés las palabras en castellano."+
" provocando que no sea claro. La solución sería colocar las palabras en inglés."+
" La mayoría de lo Sistemas Operativos están en español, por lo que este inconveniente se dará sólo en algunos casos.\n"+
" Duración Advertencia: Indica la duración que tendrá la adevertencia intermitente.\n"+
" Cantidad de repeticiones: Indica la cantidad de veces que se va a repetir el mensaje hablado.\n"+
" Decir \"Tomar Pastilla\": El mensaje hablado se iniciará diciendo \"Tomar Pastilla\".\n"+

" Botón \"Seleccionar\": Con esta opción se despliega una ventana en la cuál podrá buscar un tema o sonido de su agrado que desee escuchar durante el alerta.\n"+
" Botón \"Guardar\": Presione aquí para guardar los cambios realizados. Recuerde que si usted sale sin presionar este botón, los cambios no serán guardados.\n";
	
}

void ClickExit(object sender, RoutedEventArgs e)
{
this.Close();			
}
	}//End class
}//End namespace