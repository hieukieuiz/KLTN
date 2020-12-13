

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { BaiTuyenDungDTO } from '@/models/Interview/BaiTuyenDungDTO';
export interface GetBaiTuyenDungParams extends Pagination {
   keywords? : string
}

class BaiTuyenDungApi extends BaseApi {
    
    getBaiTuyenDung(getBaiTuyenDungParams: GetBaiTuyenDungParams) {
        return new Promise<PaginatedResponse<BaiTuyenDungDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/BaiTuyenDung`, { params: getBaiTuyenDungParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getBaiTuyenDungById(id: number) {
        return new Promise<BaiTuyenDungDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/BaiTuyenDung/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createBaiTuyenDung(baiTuyenDungDTO: BaiTuyenDungDTO) {
        return new Promise<BaiTuyenDungDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/BaiTuyenDung`,baiTuyenDungDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateBaiTuyenDung(id: number, baiTuyenDungDTO: BaiTuyenDungDTO) {
        return new Promise<BaiTuyenDungDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/BaiTuyenDung/${id}`,baiTuyenDungDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteBaiTuyenDung(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/BaiTuyenDung/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new BaiTuyenDungApi();
