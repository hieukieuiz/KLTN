

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { QuanHuyenDTO } from '@/models/QuanHuyenDTO';
export interface GetQuanHuyenParams extends Pagination {
   keywords? : string
   tinhThanhId? : number
}

class QuanHuyenApi extends BaseApi {
    
    getQuanHuyen(getQuanHuyenParams: GetQuanHuyenParams) {
        return new Promise<PaginatedResponse<QuanHuyenDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/QuanHuyen`, { params: getQuanHuyenParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getQuanHuyenById(id: number) {
        return new Promise<QuanHuyenDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/QuanHuyen/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createQuanHuyen(quanHuyenDTO: QuanHuyenDTO) {
        return new Promise<QuanHuyenDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/QuanHuyen`,quanHuyenDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateQuanHuyen(id: number, quanHuyenDTO: QuanHuyenDTO) {
        return new Promise<QuanHuyenDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/QuanHuyen/${id}`,quanHuyenDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteQuanHuyen(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/QuanHuyen/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new QuanHuyenApi();
