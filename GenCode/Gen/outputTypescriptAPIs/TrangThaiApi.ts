

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { TrangThaiDTO } from '@/models/TrangThaiDTO';
export interface GetTrangThaiParams extends Pagination {
   keywords? : string
}

class TrangThaiApi extends BaseApi {
    
    getTrangThai(getTrangThaiParams: GetTrangThaiParams) {
        return new Promise<PaginatedResponse<TrangThaiDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/TrangThai`, { params: getTrangThaiParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getTrangThaiById(id: number) {
        return new Promise<TrangThaiDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/TrangThai/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createTrangThai(trangThaiDTO: TrangThaiDTO) {
        return new Promise<TrangThaiDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/TrangThai`,trangThaiDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateTrangThai(id: number, trangThaiDTO: TrangThaiDTO) {
        return new Promise<TrangThaiDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/TrangThai/${id}`,trangThaiDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteTrangThai(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/TrangThai/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new TrangThaiApi();
