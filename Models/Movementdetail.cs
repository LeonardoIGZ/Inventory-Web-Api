﻿using System;
using System.Collections.Generic;

namespace Inventory_Web_Api.Models
{
    public partial class Movementdetail
    {
        public int MovementId { get; set; }
        public int ProductId { get; set; }
        /// <summary>
        /// Todos los movimientos manejaran cantidades en positivo, a excepción de los movimientos de ajuste que pueden manejar negativo, inidicacando así, cuando la cantidad de articulos se quiera dar de baja.
        /// </summary>
        public int Quantity { get; set; }

        public virtual Movement Movement { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}