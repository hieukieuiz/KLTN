

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { ThanhVienDuAnDTO } from '@/models/ThanhVienDuAnDTO';
export interface GetThanhVienDuAnParams extends Pagination {
   duAnId: number,
}

class ThanhVienDuAnApi extends BaseApi {
    
    getThanhVienDuAn(getThanhVienDuAnParams: GetThanhVienDuAnParams) {
        return new Promise<PaginatedResponse<ThanhVienDuAnDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/ThanhVienDuAn`, { params: getThanhVienDuAnParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createThanhVienDuAn(thanhVienDuAnDTO: ThanhVienDuAnDTO) {
        return new Promise<ThanhVienDuAnDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/ThanhVienDuAn`,thanhVienDuAnDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteThanhVienDuAn(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/ThanhVienDuAn/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
   
}
export default new ThanhVienDuAnApi();
