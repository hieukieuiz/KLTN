import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { UserDTO } from '@/models/UserDTO';
import { HocVienDTO } from '@/models/HocVienDTO';
var qs = require('qs');

export interface GetUsersParams extends Pagination {
    keywords?: string
    roles?: string[]
}

class UsersApi extends BaseApi {

    getMyRoles() {
        return new Promise<any[]>((resolve: any, reject: any) => {
            HTTP.get(`api/Users/myaccount/roles`)
                .then((response) => {
                    resolve(response.data);
                }).catch((error) => {
                    reject(error);
                })
        });
    }
    getUsers(getUsersParams: GetUsersParams) {
        return new Promise<PaginatedResponse<UserDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/Users`, {
                params: getUsersParams,
                paramsSerializer: (params) => {
                    return qs.stringify(params, { arrayFormat: 'repeat' })
                }
            })
                .then((response) => {
                    resolve(response.data);
                }).catch((error) => {
                    reject(error);
                })
        });
    }
    createUser(user: UserDTO) {
        return new Promise<UserDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/Users`, user)
                .then((response) => {
                    resolve(response.data);
                }).catch((error) => {
                    reject(error);
                })
        });
    }
    updateUser(user: UserDTO) {
        return new Promise<UserDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/Users`, user)
                .then((response) => {
                    resolve(response.data);
                }).catch((error) => {
                    reject(error);
                })
        });
    }
    resetPassword(user: UserDTO) {
        return new Promise<void>((resolve: any, reject: any) => {
            HTTP.post(`api/Users/resetpassword`, user)
                .then((response) => {
                    resolve(response.data);
                }).catch((error) => {
                    reject(error);
                })
        });
    }
    deleteUser(user: UserDTO) {
        return new Promise<void>((resolve: any, reject: any) => {
            HTTP.delete(`api/Users/${user.userName}`)
                .then((response) => {
                    resolve(response.data);
                }).catch((error) => {
                    reject(error);
                })
        });
    }
    getHocVienByUser() {
        return new Promise<HocVienDTO>((resolve: any, reject: any) => {
          HTTP.get('api/user')
            .then((response) => {
              resolve(response.data);
            })
            .catch((error) => {
              reject(error);
            });
        });
      }
}
export default new UsersApi();
