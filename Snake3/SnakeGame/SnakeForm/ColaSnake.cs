using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeForm
{
    public class ColaSnake:ObjetoSnake
    {

        #region Atributos

        ColaSnake siguientePosicion;

        #endregion

        #region Propiedades

        public int GetX
        {
            get
            {
                return this.x;
            }
           
        }

        public int GetY
        {
            get
            {
                return this.y;
            }

        }

        public ColaSnake GetSiguiente
        {
            get
            {
                return this.siguientePosicion;
            }
          
        }

        #endregion

        #region Constructores

        public ColaSnake(int x,int y)
        {
            this.x = x;
            this.y = y;
        }

        #endregion

        #region Metodos

        public void Dibujar(Graphics graficos)//voy dibujando la serpiente
        {
            if(this.siguientePosicion !=null)
            {
                this.siguientePosicion.Dibujar(graficos);
            }

            graficos.FillRectangle(new SolidBrush(Color.Blue), this.x, this.y, this.ancho, this.ancho);//instancio mis graficos
        }

        public void setEjesXeY(int x, int y)//seteo las posciciones de mis ejes
        {
            if (this.siguientePosicion != null)
            {

                this.siguientePosicion.setEjesXeY(this.x,this.y);

            }
            this.x = x;
            this.y = y;
        }


        public void AgregarSiguiente()//agrego una siguiente cola en la posicion anterior simulando la serpiente
        {
            if(this.siguientePosicion == null)
            {
                this.siguientePosicion = new ColaSnake(this.x, this.y);
            }
            else
            {
                this.siguientePosicion.AgregarSiguiente();//aplico recursividad
            }
        }

        #endregion

    }
}
