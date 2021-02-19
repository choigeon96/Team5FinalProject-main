using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class SubjectVO
    {
        public string Item_id { get; set; }  //품목
        public string Item_type { get; set; } //품목 유형
        public string Item_name { get; set; } //품명
        public string Item_unit { get; set; } //단위
        public int? Item_unit_qty { get; set; } //단위수량
        public string Import_inspection { get; set; } //수입검사 여부
        public string Process_inspection { get; set; } //공정검사 여부
        public string Shipment_inspection { get; set; } //출하검사 여부
        public string Free_of_charge { get; set; } //유무상 구분
        public string Order_company { get; set; } //발주업체
        public string Supply_company { get; set; } //납품업체
        public int Item_leadtime { get; set; } //업체조달시간
        public int Item_lorder_qty { get; set; } //최소 발주 수량
        public int Item_safety_qty { get; set; } //안전재고 수량
        public int Item_delivery_qty { get; set; } //표준불출 수량
        public string Item_grade { get; set; } //관리등급
        public string Item_manager { get; set; } //담당자
        public string Item_use { get; set; }  //사용유무
        public string Item_comment { get; set; } //비고
        public DateTime Up_date { get; set; } //최종 수정일
        public int Up_emp { get; set; } //최종 수정자
        public string In_warehouse { get; set; } //입고창고
        public string Out_warehouse { get; set; } //출고창고
        public string Extinction { get; set; } //단종유무

    }
    
}
