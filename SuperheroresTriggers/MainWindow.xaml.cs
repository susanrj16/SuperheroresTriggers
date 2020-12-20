using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;


namespace Superheroes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Superheroe superheroe;
        List<Superheroe> lista = Superheroe.GetSamples();
        int pos = 0;
        public MainWindow()
        {
            InitializeComponent();

            heroesDock.DataContext = lista;
            pagActualTextBlock.Text = "1";
            pagTotalTextBlock.Text = lista.Count.ToString();

            //Nuevo
            superheroe = new Superheroe();           
            nuevoHeroeGrid.DataContext = superheroe;
        }


        public void Avanzar_MouseUp(object sender, MouseEventArgs e)
        {
            if(pos+1 < lista.Count)
            {
                pos++;
                heroesDock.DataContext = lista[pos];
                pagActualTextBlock.Text = Convert.ToString(pos + 1);
            }
        }


        private void Avanzar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (pos + 1 < lista.Count)
            {
                pos++;
                heroesDock.DataContext = lista[pos];
                pagActualTextBlock.Text = Convert.ToString(pos + 1);
            }
        }

        private void Atras_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(pos >= 1)
            {
                pos--;
                heroesDock.DataContext = lista[pos];
                pagActualTextBlock.Text = Convert.ToString(pos+1);
                
            }
        }

        private void aceptarBoton_Click(object sender, RoutedEventArgs e)
        {
            lista.Add(superheroe);
            pagTotalTextBlock.Text = lista.Count.ToString();
            MessageBox.Show("Superhéroe insertado con éxito","Superhéroes",MessageBoxButton.OK,MessageBoxImage.Information);
            
            superheroe = new Superheroe();
            nuevoHeroeGrid.DataContext = superheroe;

        }

        private void limpiarBoton_Click(object sender, RoutedEventArgs e)
        {
            superheroe.Nombre = "";
            superheroe.Imagen = "";
            superheroe.Heroe = true;
            superheroe.Villano = false;
            superheroe.Xmen = false;
            superheroe.Vengador = false;
        }
    }
}
