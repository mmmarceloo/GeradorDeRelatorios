using GeradorDeRelatorios.Models;
using Microsoft.AspNetCore.Mvc;


namespace GeradorDeRelatorios.Controllers
{
    public class RelatoriosController : Controller
    {
        // GET: RelatoriosController
        public ActionResult Index()
        {
            @ViewBag.aviso = "";
            return View();
        }

        public ActionResult GerarRelatorio(DateTime periodo, string selecao)
        {
            if(periodo == null || periodo == DateTime.MinValue)
            {
                @ViewBag.aviso = "Insira uma data";
                return View("Views/Relatorios/index.cshtml");
            }

            var dty = "31/" + periodo.Month.ToString() + "/" + periodo.Year.ToString();
            List<Periodo> listaPeriodos = new List<Periodo>();
            try
            {
                var strJson = "";
                var path = (Directory.GetCurrentDirectory()) + "\\cadastroEmpresas.json";
                if (path != null)
                {
                    FileInfo fileInfo = new FileInfo(path);
                    using (StreamReader sr = new StreamReader(@"C:\Users\porca\source\repos\GeradorDeRelatorios\GeradorDeRelatorios\cadastroEmpresas.json"))
                    {
                        strJson = sr.ReadToEnd();
                    }

                    listaPeriodos = Periodo.JsonDesserializar(strJson);
                    List<Periodo> selecionados = listaPeriodos.FindAll(delegate (Periodo p)
                    {
                        var m = Convert.ToDateTime(dty).AddMonths(-12);
                        return (Convert.ToDateTime(p.date_create) <= Convert.ToDateTime(dty) &&
                        Convert.ToDateTime(p.date_create) > Convert.ToDateTime(m));
                    });

                    foreach (var item in selecionados)
                    {
                        Console.WriteLine(item.date_create);
                    }

                    var dataBase = DateTime.Parse(selecionados[0].date_create);

                    List<string> lista = new List<string>();
                    List<DadosEstraidos> listacompleta = new List<DadosEstraidos>();
                    foreach (var item in selecionados)
                    {
                        var dataMesAno = item.date_create.Substring(0, 7);
                        var dataMesAnoSaida = "";
                        if (!item.date_remove.Equals("NULL"))
                        {
                            dataMesAnoSaida = item.date_remove.Substring(0, 7);
                        }
                        else
                        {
                            dataMesAnoSaida = item.date_remove;
                        }

                        lista.Add(dataMesAno);
                        listacompleta.Add(new DadosEstraidos(dataMesAno, 0, item.date_create, dataMesAnoSaida));
                    }
                    var conjunto = lista.Distinct();  // Lista: Todos formatados

                    double[] contdor = new double[12];
                    int cont = 0;
                    foreach (var itemA in conjunto)
                    {
                        foreach (var itemB in lista)
                        {
                            if (itemA.Equals(itemB))
                            {
                                contdor[cont] += 1;  // quantidade de cada mes
                            }
                        }
                        cont++;
                    }

                    //contr quantos sairam no mes
                    cont = 0;
                    int[] contdorSaida = new int[12];
                    foreach (var itemA in conjunto)
                    {
                        foreach (var itemB in listacompleta)
                        {
                            if(!itemB.retencao2.Equals("NULL") && itemB.retencao2.Substring(0, 7).Equals(itemA))
                            {
                                contdorSaida[cont] += 1;
                            }
                        }
                        cont++;
                    }

                    cont = 0;
                    double[] saiu= new double[12];
                    List<QuantidadeRemove> ListaRetencao = new List<QuantidadeRemove>();
                    foreach (var itemA in conjunto)
                    {
                        foreach (var item in selecionados)
                        {
                            if (!item.date_remove.Equals("NULL") 
                                && item.date_create.Substring(0, 7).Equals(itemA))
                            {
                                var data1 = DateTime.Parse(item.date_create);
                                var data2 = DateTime.Parse(item.date_remove);

                                if (dataBase.Month == data2.Month)
                                {
                                    saiu[0] += 1;
                                }
                                else if (dataBase.AddMonths(1).Month == data2.Month)
                                {
                                    saiu[1] += 1;
                                }
                                else if (dataBase.AddMonths(2).Month == data2.Month)
                                {
                                    saiu[2] += 1;
                                }
                                else if (dataBase.AddMonths(3).Month == data2.Month)
                                {
                                    saiu[3] += 1;
                                }
                                else if (dataBase.AddMonths(4).Month == data2.Month)
                                {
                                    saiu[4] += 1;
                                }
                                else if (dataBase.AddMonths(5).Month == data2.Month)
                                {
                                    saiu[5] += 1;
                                }
                                else if (dataBase.AddMonths(6).Month == data2.Month)
                                {
                                    saiu[6] += 1;
                                }
                                else if (dataBase.AddMonths(7).Month == data2.Month)
                                {
                                    saiu[7] += 1;
                                }
                                else if (dataBase.AddMonths(8).Month == data2.Month)
                                {
                                    saiu[8] += 1;
                                }
                                else if (dataBase.AddMonths(9).Month == data2.Month)
                                {
                                    saiu[9] += 1;
                                }
                                else if (dataBase.AddMonths(10).Month == data2.Month)
                                {
                                    saiu[10] += 1;
                                }
                                else if (dataBase.AddMonths(11).Month == data2.Month)
                                {
                                    saiu[11] += 1;
                                }
                            }
                        }
                        var x = saiu;
                        var totalDoMes = contdor[cont];
                        // converter para %
                        for (int i = 0; i < contdor.Length; i++)
                        {
                            saiu[i] = Math.Round(((totalDoMes -= saiu[i]) / contdor[cont] * 100));
                        }

                        ListaRetencao.Add(new QuantidadeRemove(
                            itemA,
                            contdor[cont],
                            contdorSaida[cont],
                            ((cont < 12 ? Convert.ToString(saiu[0] + "%") : "")),
                            ((cont < 11 ? Convert.ToString(saiu[1] + "%") : "")),
                            ((cont < 10 ? Convert.ToString(saiu[2] + "%") : "")),
                            ((cont < 9 ? Convert.ToString(saiu[3] + "%") : "")),
                            ((cont < 8 ? Convert.ToString(saiu[4] + "%") : "")),
                            ((cont < 7 ? Convert.ToString(saiu[5] + "%") : "")),
                            ((cont < 6 ? Convert.ToString(saiu[6] + "%") : "")),
                            ((cont < 5 ? Convert.ToString(saiu[7] + "%") : "")),
                            ((cont < 4 ? Convert.ToString(saiu[8] + "%") : "")),
                            ((cont < 3 ? Convert.ToString(saiu[9] + "%") : "")),
                            ((cont < 2 ? Convert.ToString(saiu[10] + "%") : "")),
                            ((cont < 1 ? Convert.ToString(saiu[11] + "%") : ""))
                            ));
                        cont++;
                        dataBase = dataBase.AddMonths(1);
                        Array.Clear(saiu);
                    }
                    ViewBag.dados = ListaRetencao;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
            string endereco = "";
            if (selecao == "grafico")
                endereco = "Views/Relatorios/Grafico.cshtml";
            else
                endereco = "Views/Relatorios/Relatorio.cshtml";
            return View(endereco);
        }
    }
}
