using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class BOMVO
    {
        public int bom_id { get; set; } //bomid
        public string bom_parent_id { get; set; } // 상위품목아이디
        public string bom_parent_name { get; set; } //상위품목이름
        public string item_id { get; set; } //품목아이디
        public string item_name { get; set; } //품명
        public string item_type { get; set; } //품목타입
        public string item_unit { get; set; } //품목단위
        public int bom_use_qty { get; set; } //소요량
        public int level { get; set; } //단계
        public DateTime start_date { get; set; } //시작일
        public DateTime end_date { get; set; } //종료일
        public string bom_use { get; set; } //사용유무
        public string plan_use { get; set; } //소요계획
        public string auto_deduction { get; set; } //자동차감
        public string machine_id { get; set; } //설비아이디
        public string machine_name { get; set; } //설비명
        public string bom_comment { get; set; } //비고


        public DateTime ins_date { get; set; } //등록일
        public int ins_emp { get; set; } //등록자
        public DateTime up_date { get; set; } //수정일
        public int up_emp { get; set; } //수정자
        public string emp_name { get; set; } //수정자


    }
}
