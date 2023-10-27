# WpfExample

This repo is created by following tutorial at https://caliburnmicro.com/documentation/Tutorials/WPF/Contents with slight differences<br><br>

ViewModel and View files don't have to be in the ViewModels Views directory. CM can find them.</li>
<local:MyBootstrapper x:Key="bootstrapper" />  what's after local: must be the bootstrapper class name.  x:key is not relevant as long as it's unique.</li>


Caliburn
	1. 创建  public class MyBootstrapper: BootstrapperBase {}
		a. BootstrapperBase  来自 Caliburn.Micro 
		b. override  OnStartup（） ； 里面call  DisplayRootViewForAsync<MyMainViewModel>() 启动MyMainView
		c. MyMainViewModel 继承 Conductor ：ConductorBaseWithActiveItem ：ConductorBase ：Screen。 其他子窗口model直接继承Screen
		d. 在MainView.xml 里  <ContentControl x:Name="ActiveItem" Margin="20"/> 在  MainViewModel.OnViewLoaded()里调用
		var viewmodel = IoC.Get<CategoryViewModel>();
		return ActivateItemAsync(viewmodel, new CancellationToken());  可以加载CategoryViewModel 这里ActiveItem不能改动
		e. 为了使以上work，在bootstrapper里 override void Configure() 要加载所有用到的 ViewModel 
			private readonly SimpleContainer _container = new SimpleContainer();        
			protected override void Configure()
		        {
		            _container.Instance(_container);
		            _container
		              .Singleton<IWindowManager, WindowManager>()
		              .Singleton<IEventAggregator, EventAggregator>();
		            _container.Singleton<MyViewModel>();
			    // 必须包括MainViewModel 自身，否则无法运行。其他 ViewModel 如不包含，则无法显示。
			}
	2. 在app.xaml 里指定resource dictionary
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary>
                    <local:MyBootstrapper x:Key="bootstrapper" />
                </ResourceDictionary>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>

	3. ViewModel
		a. xml里 <Button x:Name="Edit" Width="80" Margin="5">Edit</Button>  没有action。CM会找到model里的x:Name相同名字的方法作为action， 此处即Edit()。同时，会 get  CanEdit  property，决定 Edit button是否 enable 。
		b. 也可以用   cal:Message.Attach 来实现 binding。 cal:Message.Attach="Edit()" 此时xml头里要加上 xmlns:cal="http://caliburnmicro.com"
