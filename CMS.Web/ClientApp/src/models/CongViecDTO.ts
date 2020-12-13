import { PhanViecDTO } from './PhanViecDTO';

export interface CongViecDTO { 
  id: number;
  duAnId?:number;
  trangThaiId?:number;
  loaiCongViecId?:number;
  tenCongViec:string;
  ngayTao:Date;
  ngayHetHan:Date;
  tyLeHoanThanh:number;
  moTaCongViec?:string;
  doUuTien:string;
  ngayHoanThanh?:Date;
  ngayCapNhat?:Date;
  isActive:boolean;
  thanhVienDuAnId?:number;
  soLuongChiTietCongViec?:number;
  soLuongChiTietCongViecHoanThanh?:number;
  phanViec:PhanViecDTO[];
  isOverdue:boolean;
}