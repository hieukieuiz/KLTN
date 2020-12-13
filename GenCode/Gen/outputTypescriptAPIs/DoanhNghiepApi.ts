

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { DoanhNghiepDTO } from '@/models/DoanhNghiepDTO';
import { BaiTuyenDungDTO } from '@/models/BaiTuyenDungDTO';
export interface GetDoanhNghiepParams extends Pagination {
   keywords? : string
}
export interface GetDanhSachBaiTuyenDungParams extends Pagination {
}

class DoanhNghiepApi extends BaseApi {
    
    getDoanhNghiep(getDoanhNghiepParams: GetDoanhNghiepParams) {
        return new Promise<PaginatedResponse<DoanhNghiepDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/DoanhNghiep`, { params: getDoanhNghiepParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getDoanhNghiepById(id: number) {
        return new Promise<DoanhNghiepDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/DoanhNghiep/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createDoanhNghiep(doanhNghiepDTO: DoanhNghiepDTO) {
        return new Promise<DoanhNghiepDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/DoanhNghiep`,doanhNghiepDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateDoanhNghiep(id: number, doanhNghiepDTO: DoanhNghiepDTO) {
        return new Promise<DoanhNghiepDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/DoanhNghiep/${id}`,doanhNghiepDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteDoanhNghiep(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/DoanhNghiep/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getDanhSachBaiTuyenDung(getDanhSachBaiTuyenDungParams: GetDanhSachBaiTuyenDungParams) {
        return new Promise<PaginatedResponse<BaiTuyenDungDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/DoanhNghiep/danhsachbaituyendung`, { params: getDanhSachBaiTuyenDungParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new DoanhNghiepApi();
