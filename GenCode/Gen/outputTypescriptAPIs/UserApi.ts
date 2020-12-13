

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { UngVienDTO } from '@/models/UngVienDTO';

class UserApi extends BaseApi {
    
    getHocVienByUsername() {
        return new Promise<PaginatedResponse<UngVienDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/User`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new UserApi();
