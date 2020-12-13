import { ThanhVienDuAnDTO } from './ThanhVienDuAnDTO';
import { ChiTietCongViecDTO } from './ChiTietCongViecDTO';

export interface BaoCaoDTO {
  id: number;
  chiTietCongViecId?: number;
  thanhVienDuAnId?: number;
  noiDung: string;
  thoiGianTao:Date;
  thanhVienDuAn: ThanhVienDuAnDTO;
  chiTietCongViec:ChiTietCongViecDTO;
}