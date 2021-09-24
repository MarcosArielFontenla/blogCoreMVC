using System;
using System.Collections.Generic;
using System.Text;
using BlogCore.Models;

namespace BlogCore.AccesoDatos.Data.Repository
{
    public interface ISliderRepository : IRepository<Slider>
    {
        void Update(Slider slider);
    }
}
