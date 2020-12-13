import store from '../store/store';
export declare class CommonFunctionsService {
    checkRole(roleId: string): boolean;
    genPassword(): string;
}
export class CommonFunctions implements CommonFunctionsService {
    checkRole(roleId: string): boolean {
        if(store.state.user && store.state.user.Profile && store.state.user.Profile.UserRoles)
            return store.state.user.Profile.UserRoles.indexOf(roleId) != -1;
        return false;
    }
    shuffle(str: string) {
        var array = str.split('');
        var tmp, current, top = array.length;

        if (top) while (--top) {
            current = Math.floor(Math.random() * (top + 1));
            tmp = array[current];
            array[current] = array[top];
            array[top] = tmp;
        }

        return array.join('');
    }
    pick(str: string, min: number, max?: number) {
        var n, chars = '';

        if (typeof max === 'undefined') {
            n = min;
        } else {
            n = min + Math.floor(Math.random() * (max - min));
        }

        for (var i = 0; i < n; i++) {
            chars += str.charAt(Math.floor(Math.random() * str.length));
        }

        return chars;
    }
    genPassword(): string {
        let specials = '!@#$%^&*()_+{}:"<>?\|[];\',./`~';
        let lowercase = 'abcdefghijklmnopqrstuvwxyz';
        let uppercase = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
        let numbers = '0123456789';

        let all = specials + lowercase + uppercase + numbers;

        let password = (this.pick(specials, 1) + this.pick(lowercase, 4) + this.pick(numbers, 1) + this.pick(uppercase, 1));
        password = this.shuffle(password);
        return password;
    }
}
const install = (Vue: any) => {
    Vue.prototype.$commonFunctions = new CommonFunctions();
};
export default install;