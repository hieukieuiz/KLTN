

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { XaPhuongDTO } from '@/models/XaPhuongDTO';
export interface GetXaPhuongParams extends Pagination {
   keywords? : string
   quanHuyenId? : number
}

class XaPhuongApi extends BaseApi {
    
    getXaPhuong(getXaPhuongParams: GetXaPhuongParams) {
        return new Promise<PaginatedResponse<XaPhuongDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/XaPhuong`, { params: getXaPhuongParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getXaPhuongById(id: number) {
        return new Promise<XaPhuongDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/XaPhuong/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createXaPhuong(xaPhuongDTO: XaPhuongDTO) {
        return new Promise<XaPhuongDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/XaPhuong`,xaPhuongDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateXaPhuong(id: number, xaPhuongDTO: XaPhuongDTO) {
        return new Promise<XaPhuongDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/XaPhuong/${id}`,xaPhuongDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteXaPhuong(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/XaPhuong/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new XaPhuongApi();
