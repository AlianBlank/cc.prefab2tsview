/**
 * generate by time :2019/12/30 16:44:13
 */
import Utility from '../Script/Utils/Utility';

const { ccclass, property } = cc._decorator;

@ccclass
export default class TView extends cc.Component {    private A:cc.Node;    private A_B:cc.Node;    private AA:cc.Node;    private AA_BB:cc.Node;
    onLoad() {
        this.A = Utility.findChildByName(this.node,'A');        this.A_B = Utility.findChildByName(this.node,'A/B');        this.AA = Utility.findChildByName(this.node,'AA');        this.AA_BB = Utility.findChildByName(this.node,'AA/BB');    }

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
