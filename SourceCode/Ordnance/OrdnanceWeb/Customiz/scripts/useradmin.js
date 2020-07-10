/**

 @Name：layuiAdmin 用户管理 管理员管理 角色管理
 @Author：star1029
 @Site：http://www.layui.com/admin/
 @License：LPPL
    
 */

layui.define(['table', 'form'], function(exports) {
	var $ = layui.$,
		table = layui.table,
		form = layui.form;

	//用户管理
	table.render({
		elem: '#LAY-user-manage',
		url: '/User/GetUser' //模拟接口
			,
		cols: [
			[{
				type: 'checkbox',
				fixed: 'left'
			}, {
				field: 'id',
				title: 'ID',
				sort: true
			}, {
				field: 'username',
				title: '军械名称'
			}, {
				field: 'cangku',
				title: '所属仓库'
			}, {
				field: 'a1',
				title: '库存数量'
			}, {
				field: 'a2',
				title: '借出数量'
			}, {
				field: 'a3',
				title: '总数量'
			}, , {
				field: 'a4',
				title: '报废数量'
			}, , {
				field: 'jointime',
				title: '创建时间'
			}, {
				title: '操作',
				width: 150,
				align: 'center',
				fixed: 'right',
				toolbar: '#table-useradmin-webuser'
			}]
		],
		page: true,
		limit: 30,
		height: 'full-220',
		text: '对不起，加载出现异常！'
	});

	//监听工具条
	table.on('tool(LAY-user-manage)', function(obj) {
		var data = obj.data;
		if(obj.event === 'del') {
			layer.prompt({
				formType: 1,
				title: '敏感操作，请验证口令'
			}, function(value, index) {
				layer.close(index);

				layer.confirm('真的删除行么', function(index) {
					obj.del();
					layer.close(index);
				});
			});
		} else if(obj.event === 'edit') {
			var tr = $(obj.tr);

			layer.open({
				type: 2,
				title: '编辑用户',
				content: '/User/GetUser',
				maxmin: true,
				area: ['500px', '450px'],
				btn: ['确定', '取消'],
				yes: function(index, layero) {
					var iframeWindow = window['layui-layer-iframe' + index],
						submitID = 'LAY-user-front-submit',
						submit = layero.find('iframe').contents().find('#' + submitID);

					//监听提交
					iframeWindow.layui.form.on('submit(' + submitID + ')', function(data) {
						var field = data.field; //获取提交的字段

						//提交 Ajax 成功后，静态更新表格中的数据
						//$.ajax({});
						table.reload('LAY-user-front-submit'); //数据刷新
						layer.close(index); //关闭弹层
					});

					submit.trigger('click');
				},
				success: function(layero, index) {

				}
			});
		}
	});


	//角色管理
	table.render({
		elem: '#LAY-user-back-role',
		url: '/User/GetUser' //模拟接口
			,
		cols: [
			[{
				type: 'checkbox',
				fixed: 'left'
			}, {
				field: 'id',
				width: 80,
				title: 'ID',
				sort: true
			}, {
				field: 'rolename',
				title: '角色名'
			}, {
				field: 'limits',
				title: '拥有权限'
			}, {
				field: 'descr',
				title: '具体描述'
			}, {
				title: '操作',
				width: 150,
				align: 'center',
				fixed: 'right',
				toolbar: '#table-useradmin-admin'
			}]
		],
		text: '对不起，加载出现异常！'
	});

	//监听工具条
	table.on('tool(LAY-user-back-role)', function(obj) {
		var data = obj.data;
		if(obj.event === 'del') {
			layer.confirm('确定删除此角色？', function(index) {
				obj.del();
				layer.close(index);
			});
		} else if(obj.event === 'edit') {
			var tr = $(obj.tr);

			layer.open({
				type: 2,
				title: '编辑角色',
				content: '/User/GetUser',
				area: ['500px', '480px'],
				btn: ['确定', '取消'],
				yes: function(index, layero) {
					var iframeWindow = window['layui-layer-iframe' + index],
						submit = layero.find('iframe').contents().find("#LAY-user-role-submit");

					//监听提交
					iframeWindow.layui.form.on('submit(LAY-user-role-submit)', function(data) {
						var field = data.field; //获取提交的字段

						//提交 Ajax 成功后，静态更新表格中的数据
						//$.ajax({});
						table.reload('LAY-user-back-role'); //数据刷新
						layer.close(index); //关闭弹层
					});

					submit.trigger('click');
				},
				success: function(layero, index) {

				}
			})
		}
	});

	exports('useradmin', {})
});