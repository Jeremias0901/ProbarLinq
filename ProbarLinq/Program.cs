using System;
using System.Collections.Generic;
using System.Linq;

namespace ProbarLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            ControlEmpresasEmpleado tableEmpresasEmpleados = new ControlEmpresasEmpleado();
            tableEmpresasEmpleados.getCeo();

            tableEmpresasEmpleados.getEnterpriseName(new Empleado { Id = 5, Nombre = "Gerardo", Cargo = "FrontEnd", EmpresaId = 1, Salario = 1500.75});
            tableEmpresasEmpleados.getEmployeesYouTube();


            // The Three Parts of a LINQ Query:
            //  1. Data source.
            int[] numbers = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // 2. Query creation.
            // numQuery is an IEnumerable<int>
            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            List<int> numQuery2 =
                (from num in numbers
                 where (num % 2) == 0
                 select num).ToList();

            // or like this:
            // numQuery3 is still an int[]

            var numQuery3 =
                (from num in numbers
                 where (num % 2) == 0
                 select num).ToArray();

            // 3. Query execution.
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }
            Console.WriteLine();
            foreach (int num in numQuery2)
            {
                Console.Write("{0,1} ", num);
            }
            Console.WriteLine();
            foreach (int num in numQuery3)
            {
                Console.Write("{0,1} ", num);
            }
        }
    }

    class ControlEmpresasEmpleado
    {
        public ControlEmpresasEmpleado()
        {
            ListEmpresas =  new List<Empresa>();
            ListEmpleados = new List<Empleado>();

            ListEmpresas.Add(new Empresa { Id = 1, Nombre = "Google" });
            ListEmpresas.Add(new Empresa { Id = 2, Nombre = "Youtube"});

            ListEmpleados.Add(new Empleado { Id = 1, Nombre = "Jeremias", Cargo = "CEO", EmpresaId = 1, Salario = 100.50 });
            ListEmpleados.Add(new Empleado { Id = 2, Nombre = "Natanael", Cargo = "CEO", EmpresaId = 2, Salario = 50.50 });
            ListEmpleados.Add(new Empleado { Id = 3, Nombre = "Lucas", Cargo = "Co-CEO", EmpresaId = 2, Salario = 150.50 });
            ListEmpleados.Add(new Empleado { Id = 4, Nombre = "Juan", Cargo = "Co-CEO", EmpresaId = 2, Salario = 50.50 });
        }
        public List<Empresa> ListEmpresas;
        public List<Empleado> ListEmpleados;

        public void getCeo()
        {
            // IEnumerable<Empleado> ceos = (from empleado in ListEmpleados where empleado.Cargo == "CEO" select empleado).FirstOrDefault();
            IEnumerable<Empleado> ceos = from empleado in ListEmpleados where empleado.Cargo == "CEO" select empleado;

            foreach (Empleado e in ceos)
            {
                // Console.WriteLine(e.Nombre);
                e.getDatosEmpleado();
            }
        }

        public void getEnterpriseName(Empleado e)
        {
            IEnumerable<Empresa> empresaResultante = from empresa in ListEmpresas where e.EmpresaId == empresa.Id select empresa;

            Console.WriteLine();
            e.getDatosEmpleado();
            Console.WriteLine("pertenece a:");
            empresaResultante.First().getDatosEmpresa();
            Console.WriteLine();
        }

        public void getEmployeesYouTube()
        {
            IEnumerable<Empleado> empleadosResultantes = from empleado in ListEmpleados
                                                           join empresa in ListEmpresas
                                                             on empleado.EmpresaId equals empresa.Id
                                                         where empresa.Nombre == "Youtube"
                                                         select empleado;

            foreach (Empleado empleado1 in empleadosResultantes)
            {
                empleado1.getDatosEmpleado();
            }
        }
    }

    class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public void getDatosEmpresa()
        {
            Console.WriteLine("Empresa {0} con Id {1}", Nombre, Id);
        }
    }

    class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }
        public int  EmpresaId { get; set; }// clave foranea

        public void getDatosEmpleado()
        {
            Console.WriteLine("Empleado {0} con Id {1}, Cargo {2}, Salario {3}, En la Empresa {4}", Nombre, Id, Cargo, Salario, EmpresaId);
        }
    }
}
