﻿

import { TinhThanhDTO } from '@/models/TinhThanhDTO';
import { TrangThaiDTO } from '@/models/TrangThaiDTO'; 

export interface UngVienDTO { 
    id: number;
    tinhThanhId: number;
    trangThaiId: number;
    quanHuyenId: number;
    xaPhuongId: number;
    truongDaiHocId: number;
    hoTen: string;
    ngaySinh: Date;
    sdt: string;
    account: string;
    email: string;
    cmtnd: string;
    diaChi: string;
    linkAnhCaNhan: string;
    linkAnhMatTruoc: string;
    linkAnhMatSau: string;
    bietQuaFaceBook: boolean;
    bietQuaWeb: boolean;
    bietQuaGioiThieu: boolean;
    tenNguoiGioiThieu: string;
    linkFaceBook: string;
    linkSkype: string;
    linkZalo: string;
    daDienDu: boolean;
    tenKhoa: string;
    namThu: number;
    tinhThanh: TinhThanhDTO;
    trangThai: TrangThaiDTO;
}