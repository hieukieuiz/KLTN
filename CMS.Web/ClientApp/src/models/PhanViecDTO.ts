import {ThanhVienDuAnDTO} from './ThanhVienDuAnDTO'
export interface PhanViecDTO { 
  id: number;
  congViecId?:number;
  thanhVienDuAnId?:number;
  ngayPhanViec:Date;
  thanhVienDuAn:ThanhVienDuAnDTO[];
}