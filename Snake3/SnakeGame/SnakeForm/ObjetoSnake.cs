using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeForm
{
   public abstract class ObjetoSnake
    {

        #region Atributos

      protected int x;
      protected int y;
      protected int ancho;

        #endregion

        #region Constructores

        public ObjetoSnake()//constructor
        {
            this.ancho = 10;
        }

        #endregion

        #region Metodos

        public bool Interseccion(ObjetoSnake O)//Metodo para detectar colisiones
        {
            int diferenciaX = Math.Abs(this.x - O.x);//calculando la diferencia entra las posiciones y el objeto para saber si chocan
            int diferenciaY = Math.Abs(this.y - O.y);
            bool retorno=false;

            if(diferenciaX >= 0 && diferenciaX < this.ancho && diferenciaY >=0 && diferenciaY < this.ancho)//va a preguntar si estan colisionando
            {
                retorno = true;
            }
            return retorno;
        }

        #endregion

    }
}
