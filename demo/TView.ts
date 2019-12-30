﻿/**
 * generate by time :2019/12/30 16:44:13
 */
import Utility from '../Script/Utils/Utility';

const { ccclass, property } = cc._decorator;

@ccclass
export default class TView extends cc.Component {
    onLoad() {
        this.A = Utility.findChildByName(this.node,'A');

    /**
    * 隐藏当前对象
    */
    public hide(): void {
        this.node.active = false;
    }
    /**
    * 显示当前对象
    */
    public show(): void {
        this.node.active = true;
    }
}