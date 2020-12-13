import { ThanhVienDuAnDTO } from './ThanhVienDuAnDTO';
import { ChiTietCongViecDTO } from './ChiTietCongViecDTO';
import { TrangThaiDTO } from './TrangThaiDTO';

export interface LichSuChiTietCongViecDTO { 
  id: number;
  trangThaiId?:number;
  chiTietCongViecId?:number;
  thanhVienDuAnId?:number;
  ngayCapNhat?:Date;
  thuTu?:number
  ghiChu?:string;
  thanhVienDuAn:ThanhVienDuAnDTO;
  chiTietCongViec:ChiTietCongViecDTO;
  trangThai:TrangThaiDTO;
}