using LithologyLog.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LithologyLog.Web.Repository
{
    public interface IColumRepository
    {
        void Hide(params int[] indexes);
        void Show(params int[] indexes);
        IList<Column> GetColumns();
        void Fill();
        void ReFill();
    }

    public class ColumRepository : IColumRepository
    {
        private IList<Column> _columns = null;

        public void Hide(params int[] indexes)
        {
            SetVisible(indexes, false);
        }

        public void Show(params int[] indexes)
        {
            SetVisible(indexes, true);
        }

        private void SetVisible(int[] indexes, bool visibility)
        {
            _columns.Where(x => indexes.Contains(x.Index))
                    .ToList()
                    .ForEach(x => x.Visible = visibility);
        }

        public IList<Column> GetColumns()
        {
            var nonVisibileCount = _columns.Count(x => !x.Visible);

            var nonVisibileWidthSum = _columns.Where(x => !x.Visible).Sum(x => x.Width);

            float eachColumIncreaseSize = nonVisibileWidthSum / (ColumnSetting.ColumnCount - nonVisibileCount - 2);

            foreach (var item in _columns)
            {
                if (item.Visible && item.Index > 2)
                {
                    item.IncreaseSize = eachColumIncreaseSize;

                    item.Width += eachColumIncreaseSize;
                }
            }

            _columns = _columns.OrderBy(x => x.Order).ToList();

            for (int i = 0; i < _columns.Count; i++)
            {
                if (i == 0)
                {
                    _columns[i].X = _columns[i].Width;
                }
                else
                {
                    _columns[i].X = _columns.Last(x => x.Order < _columns[i].Order && x.Visible).X + _columns[i].Width;
                }
            }

            _columns = _columns.OrderBy(x => x.Index).ToList();

            return _columns;
        }

        public void Fill()
        {
            if (_columns == null)
            {
                string lang = System.Threading.Thread.CurrentThread.CurrentCulture.Name;

                string jsonColumns = File.ReadAllText(Path.Combine("wwwroot", $"ColumnList/ColumnList_{lang}.json"));

                _columns = JsonConvert.DeserializeObject<List<Column>>(jsonColumns);

            }
        }

        public void ReFill()
        {
            Fill();
        }
    }
}
