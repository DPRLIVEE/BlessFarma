using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace DTO
{
    public class ClassResultV
    {
        private string _errorEx;
        private string _errorMsj;
        private string _lugarError;

        /// <summary>
        ///     Lista de  dto's
        /// </summary>
        public List<DtoB> List { get; set; }

        /// <summary>
        ///     Tabla de resultado (GET or SET)
        /// </summary>
        [Browsable(false)]
        public DataTable DT { get; set; }

        /// <summary>
        ///     DataSet de resultado (GET or SET)
        /// </summary>
        [Browsable(false)]
        public DataSet DS { get; set; }

        /// <summary>
        ///     Nos indica si hubo algun error (GET)
        /// </summary>
        [Browsable(false)]
        public bool HuboError { get; private set; }

        /// <summary>
        ///     Lugar de donde se produjo el error (SET)
        /// </summary>
        [Browsable(false)]
        public string LugarError
        {
            set { _lugarError = value; }
        }

        /// <summary>
        ///     Msj de error que vera el Usuario (GET or SET)
        /// </summary>
        [Browsable(false)]
        public string ErrorMsj
        {
            get { return _errorMsj; }
            set
            {
                _errorMsj = value;
                HuboError = true;
            }
        }

        /// <summary>
        ///     Msj de error que provoca la Excepcion (SET)
        /// </summary>
        [Browsable(false)]
        public string ErrorEx
        {
            set { _errorEx = value; }
        }

        /// <summary>
        ///     Nos muestra el detalle del error (GET)
        /// </summary>
        [Browsable(false)]
        public string Detalle
        {
            get { return String.Format("{0}\n\rLUGAR DE ERROR :{1}", _errorEx, _lugarError); }
        }


        /// <summary>
        ///     Metodo de conversion entre listas (DtoB a T)
        /// </summary>
        /// <typeparam name="T">Tipo de Dto a la cual se convertira la lista</typeparam>
        /// <returns></returns>
        public List<T> ConvertToGenericList<T>()
        {
            if (List == null) List = new List<DtoB>();
            var arrayList = new ArrayList(List);
            return new List<T>(arrayList.ToArray(typeof(T)) as T[]);
        }
    }
}