﻿

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { UngVienDTO } from '@/models/UngVienDTO';
export interface GetUngVienParams extends Pagination {
   keywords? : string
   tinhThanhId? : number
}

class UngVienApi extends BaseApi {
    
    getUngVien(getUngVienParams: GetUngVienParams) {
        return new Promise<PaginatedResponse<UngVienDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/UngVien`, { params: getUngVienParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getUngVienById(id: number) {
        return new Promise<UngVienDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/UngVien/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getUngVienByUsername() {
        return new Promise<UngVienDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/UngVien/thongtincanhan`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getUngVienByUsername1() {
        return new Promise<UngVienDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/UngVien/cvungvien`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateThongTinCaNhanUngVien(ungVienDTO: UngVienDTO) {
        return new Promise<UngVienDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/UngVien/capnhatthongtincanhan`,ungVienDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createUngVien(ungVienDTO: UngVienDTO) {
        return new Promise<UngVienDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/UngVien`,ungVienDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateUngVien(id: number, UngVienDTO: UngVienDTO) {
        return new Promise<UngVienDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/UngVien/${id}`,UngVienDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteUngVien(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/UngVien/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new UngVienApi();
