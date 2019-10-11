using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeForm
{
    public class ComidaSnake:ObjetoSnake
    {

        #region Constructores

        public ComidaSnake()
        {
            this.x = GenerarRandom(78);//el random con el tamaño del canvas y me va a generar un numero random entre 0 y 780 de 10 en 10 tipo cuadricula
            this.y = GenerarRandom(40); //lo mismo con el eje y;
        }

        #endregion

        #region Metodos

        public void DibujarComida(Graphics graficos)//dibujo la comida de la serpiente
        {
            graficos.FillRectangle(new SolidBrush(Color.Red), this.x, this.y, this.ancho, this.ancho);//instancio mis graficos
        }

        public int GenerarRandom(int miNumero)//genero un numero random donde va a aparecer la comida
        {
            Random numeroRandom = new Random();
            int numero;
            numero = numeroRandom.Next(0, miNumero) * 10;

            return numero;
        }

        public void ColocarComida()//coloco la comida en el eje deseado
        {
            this.x = GenerarRandom(78);
            this.y = GenerarRandom(40);
        }

        #endregion

    }
}
