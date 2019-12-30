/**
 * 工具集
 */
export default class Utility {
 
    /**
     * 根据节点名称获取目标节点下的节点
     * 如果遇见多个相同节点。返回第一个
     * @param {cc.Node} target 查找根节点
     * @param {string} childName 节点名称 使用/分割
     * @returns {cc.Node | null}
     */
    public static findChildByName(target: cc.Node, childName: string) {
        if (childName == null || childName.length <= 0) {
            console.log(' childName == null');
            return null;
        }
        let names: string[] = childName.split('/');
        let name = '';
        if (names.length > 0) {
            name = names[0];
        } else {
            console.log(' name == null ==>' + names);
            return null;
        }

        let result = target.getChildByName(name);
        if (result == null) {
            console.log(' not found ==>' + name);
            return null;
        } else {
            let split = names.slice(1);
            if (split.length > 0) {
                result = this.findChildByName(result, split.join('/'));
            }
        }
        return result;
    }

}
