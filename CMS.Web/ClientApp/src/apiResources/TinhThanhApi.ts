

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { TinhThanhDTO } from '@/models/TinhThanhDTO';
export interface GetTinhThanhParams extends Pagination {
   keywords? : string
}

class TinhThanhApi extends BaseApi {
    
    getTinhThanh(getTinhThanhParams: GetTinhThanhParams) {
        return new Promise<PaginatedResponse<TinhThanhDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/TinhThanh`, { params: getTinhThanhParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getTinhThanhById(id: number) {
        return new Promise<TinhThanhDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/TinhThanh/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createTinhThanh(tinhThanhDTO: TinhThanhDTO) {
        return new Promise<TinhThanhDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/TinhThanh`,tinhThanhDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateTinhThanh(id: number, tinhThanhDTO: TinhThanhDTO) {
        return new Promise<TinhThanhDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/TinhThanh/${id}`,tinhThanhDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteTinhThanh(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/TinhThanh/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new TinhThanhApi();
