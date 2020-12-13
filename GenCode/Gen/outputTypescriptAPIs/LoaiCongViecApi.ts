

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { LoaiCongViecDTO } from '@/models/LoaiCongViecDTO';
import { QuyenDTO } from '@/models/QuyenDTO';
export interface GetLoaiCongViecParams extends Pagination {
   keywords? : string
}

class LoaiCongViecApi extends BaseApi {
    
    getLoaiCongViec(getLoaiCongViecParams: GetLoaiCongViecParams) {
        return new Promise<PaginatedResponse<LoaiCongViecDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/LoaiCongViec`, { params: getLoaiCongViecParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getLoaiCongViecById(id: number) {
        return new Promise<LoaiCongViecDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/LoaiCongViec/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createLoaiCongViec(loaiCongViecDTO: LoaiCongViecDTO) {
        return new Promise<QuyenDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/LoaiCongViec`,loaiCongViecDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateLoaiCongViec(id: number, loaiCongViecDTO: LoaiCongViecDTO) {
        return new Promise<LoaiCongViecDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/LoaiCongViec/${id}`,loaiCongViecDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteLoaiCongViec(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/LoaiCongViec/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new LoaiCongViecApi();
