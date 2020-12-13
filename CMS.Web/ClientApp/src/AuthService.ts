import { UserManager, WebStorageStateStore, User } from 'oidc-client';
import UserApi from './apiResources/UserApi';

export default class AuthService {
    //private userManager: UserManager;

    constructor() {
        const settings: any = {
            userStore: new WebStorageStateStore({ store: window.localStorage }),
            authority: process.env.VUE_APP_STS_DOMAIN,
            client_id: process.env.VUE_APP_CLIENT_ID,
            redirect_uri: process.env.VUE_APP_URL + '/#/callback',
            accessTokenExpiringNotificationTime: 10,
            automaticSilentRenew: true,
            silent_redirect_uri: process.env.VUE_APP_URL + '/silent-renew.html',
            response_type: 'code',
            scope: 'openid profile Api1',
            post_logout_redirect_uri: process.env.VUE_APP_URL,
            filterProtocolClaims: true,
        };

        //this.userManager = new UserManager(settings);
    }

    // public getUser(): Promise<User | null> {
    //     return this.userManager.getUser();
    // }

    // public login(): Promise<void> {
    //     return this.userManager.signinRedirect();
    // }

    // public logout(): Promise<void> {
    //     return this.userManager.signoutRedirect();
    // }

    // public getAccessToken(): Promise<string> {
    //     return this.userManager.getUser().then((data: any) => {
    //         return data.access_token;
    //     });
    // }
    // Get the user roles logged in
    // public getRole(): Promise<any> {
    //     return new Promise((resolve, reject) => {
    //         this.userManager.getUser().then((user: any) => {
    //             if (user == null) {
    //                 this.login()
    //                 return resolve(null)
    //             } else {
    //                 return resolve(user.profile.role)
    //             }
    //         }).catch(function (err) {
    //             console.log(err)
    //             return reject(err)
    //         });
    //     })
    // }

    public getRoles(): Promise<any> {
        return new Promise((resolve, reject) => {
            UserApi.getMyRoles().then(res => {
                return resolve(res)
            }).catch(function (err) {
                console.log(err)
                return reject(err)
            });
        })
    }
}