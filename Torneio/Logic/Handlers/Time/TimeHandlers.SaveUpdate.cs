using Data;
using Logic.Model;

namespace Logic.Handlers
{
    public partial class TimeHandlers
    {

        
        public string Salvar(TimeModel model)
        {
            if (Regra_NomeIdentico(model))   
                return "Já Existente";

            db.Times.InsertOnSubmit(
                                TimeModel.TransformarParaEntidade(model)
                                   );
                db.SubmitChanges();
                return "Ok";
        }

        public string Update(TimeModel model)
        {            var objeto = Carregar(model.Id);
            objeto.Nome = model.Nome;
            Atualizar(TimeModel.TransformarParaEntidade(objeto));
            return "Ok";
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="objeto"></param>
        private void Atualizar(Time objeto)
        {
            //TODO:Verificar
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, objeto);


            db.SubmitChanges();
        }
    }
}
