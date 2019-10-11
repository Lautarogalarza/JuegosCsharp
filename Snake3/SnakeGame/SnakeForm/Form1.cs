using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace SnakeForm
{
    public partial class Form1 : Form
    {

        #region Atributos

        private ColaSnake cabeza;
        private Graphics nuevoGrafico;
        private ComidaSnake nuevaComida;
        private int direccionX = 0;
        private int direccionY = 0;
        private int cuadro = 10;
        private bool ejeX = true;
        private bool ejeY = true;
        private int puntajeJuego = 0;
        private int puntajeMaximo = 0;

        #endregion

        #region Constructores

        public Form1()
        {
            InitializeComponent();
            this.cabeza = new ColaSnake(10, 10);
            this.nuevaComida = new ComidaSnake();
            this.nuevoGrafico = this.canvas.CreateGraphics();//propiedad instanciada para dibujar
        }

        #endregion

        #region Bucles

        private void bucle_Tick(object sender, EventArgs e)//va a resetar la imagen en el bucle
        {

            this.nuevoGrafico.Clear(Color.White);
            this.cabeza.Dibujar(nuevoGrafico);//le paso mi propiedad al metedo de la clase cola
            this.nuevaComida.DibujarComida(nuevoGrafico);
            this.Movimiento();
            this.ColisionSerpiente();
            this.ColisionParedes();

            if (cabeza.Interseccion(nuevaComida)) //esto funciona por polimorfismo ya que una comida sigue siendo un objeto snake
            {
                this.nuevaComida.ColocarComida();//voy a detectar cuando el objeto cola colisione con el objeto comida
                this.cabeza.AgregarSiguiente();//voy agregando una "cabeza" en la poscicion anterior de la otra para simular el crecimiento de la serpiente
                this.puntajeJuego++;

                if(this.bucle.Interval >10)
                {
                this.bucle.Interval--;
                }
               this.lvlPuntos.Text = puntajeJuego.ToString();//cada vez que colisiona con la comida suma el puntaje
            }

        }

        #endregion

        #region Movimientos

        private void Movimiento()
        {
            this.cabeza.setEjesXeY(this.cabeza.GetX + this.direccionX, this.cabeza.GetY + this.direccionY);//esto va a mover constantementa la cabeza de la serpiente de 10 en 10
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.ejeX)//si esta activo nos movemos en y
            {
                if (e.KeyCode == Keys.Up)
                {
                    this.direccionY = -cuadro;
                    this.direccionX = 0;
                    this.ejeX = false;
                    this.ejeY = true;
                }
                if (e.KeyCode == Keys.Down)
                {
                    this.direccionY = cuadro;
                    this.direccionX = 0;
                    this.ejeX = false;
                    this.ejeY = true;
                }
            }

            if (this.ejeY)//si esta activo nos movemos en x
            {
                if (e.KeyCode == Keys.Right)
                {
                    this.direccionX = cuadro;
                    this.direccionY = 0;
                    this.ejeX = true;
                    this.ejeY = false;
                }
                if (e.KeyCode == Keys.Left)
                {
                    this.direccionY = 0;
                    this.direccionX = -cuadro;
                    this.ejeX = true;
                    this.ejeY = false;
                }
            }
        }

        #endregion

        #region Colisiones

        private void ColisionParedes()//si choca con alguna pared se reinicia el programa
        {
            if (this.cabeza.GetX < 0 || this.cabeza.GetX > 770 || this.cabeza.GetY < 0 || this.cabeza.GetY > 390)//si se choca con alguno de los bordes rompe tomando en cuenta el tamaño de la serpiente
            {
                this.FinDelJuego();
            }
        }

        private void ColisionSerpiente()//manejo de exepciones
        {
            ColaSnake aux;

            try
            {
                aux = cabeza.GetSiguiente.GetSiguiente;//consigo el tercer cuadro al pirncipio del juego
            }
            catch (Exception)
            {

                aux = null;
            }

            while (aux != null)//se va a ejecutar hasta que mi auxiliar deje de ser nulo
            {
                if (cabeza.Interseccion(aux))//si cabeza choca con el aux
                {
                    this.FinDelJuego();//finalizo el juego
                }
                else
                {
                    aux = aux.GetSiguiente;//si el siguiente es nulo rompe
                }
            }

        }

        private void FinDelJuego()//Reimicio los valores en 0 para un nuevo juego
        {
            this.lvlPuntos.Text = "0";
            this.ejeX = true;
            this.ejeY = true;
            this.direccionX = 0;
            this.direccionY = 0;
            this.cabeza = new ColaSnake(10, 10);
            this.nuevaComida = new ComidaSnake();
            MessageBox.Show("Puntaje conseguido: " + this.puntajeJuego.ToString(), "PERDISTE!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);            
            if (this.puntajeJuego > this.puntajeMaximo)
            {
            this.puntajeMaximo = this.puntajeJuego;
                this.lvlPuntajeMaximo.Text = this.puntajeMaximo.ToString();
            }
            this.puntajeJuego = 0;
        }

        #endregion

    }
}
