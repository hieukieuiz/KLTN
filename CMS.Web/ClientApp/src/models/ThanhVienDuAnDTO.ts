import { HocVienDTO } from './HocVienDTO';
import { QuyenDuAnDTO } from './QuyenDuAnDTO';

export interface ThanhVienDuAnDTO { 
  id: number;
  hocVienId?:number;
  quyenDuAnId?:number;
  ngayThamGia:Date;
  ghiChu:string;
  hocVien:HocVienDTO;
  quyenDuAn:QuyenDuAnDTO;
}