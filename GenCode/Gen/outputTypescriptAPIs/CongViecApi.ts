

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { CongViecDTO } from '@/models/CongViecDTO';
export interface GetCongViecParams extends Pagination {
   keywords? : string
   duAnId? : number
   trangThaiId? : number
   loaiCongViecId? : number
}

class CongViecApi extends BaseApi {
    
    getCongViec(getCongViecParams: GetCongViecParams) {
        return new Promise<PaginatedResponse<CongViecDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/CongViec`, { params: getCongViecParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getCongViecById(id: number) {
        return new Promise<CongViecDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/CongViec/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createCongViec(congViecDTO: CongViecDTO) {
        return new Promise<CongViecDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/CongViec`,congViecDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateCongViec(id: number, congViecDTO: CongViecDTO) {
        return new Promise<CongViecDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/CongViec/${id}`,congViecDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteCongViec(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/CongViec/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new CongViecApi();
