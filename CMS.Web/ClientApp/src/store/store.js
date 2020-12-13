"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var vue_1 = require("vue");
var vuex_1 = require("vuex");
var state_1 = require("./state");
var mutations_1 = require("./mutations");
var plugins_1 = require("./plugins");
vue_1.default.use(vuex_1.default);
exports.default = new vuex_1.default.Store({
    state: state_1.state,
    mutations: mutations_1.default,
    plugins: plugins_1.default
});
//# sourceMappingURL=store.js.map