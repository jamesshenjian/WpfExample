# WpfExample

This repo is created by following tutorial at https://caliburnmicro.com/documentation/Tutorials/WPF/Contents with slight differences<br><br>

<xmp>

ViewModel and View files don't have to be in the ViewModels Views directory. CM can find them.</li>
<local:MyBootstrapper x:Key="bootstrapper" />  what's after local: must be the bootstrapper class name.  x:key is not relevant as long as it's unique.</li>


Caliburn
	1. ����  public class MyBootstrapper: BootstrapperBase {}
		a. BootstrapperBase  ���� Caliburn.Micro 
		b. override  OnStartup���� �� ����call  DisplayRootViewForAsync<MyMainViewModel>() ����MyMainView
		c. MyMainViewModel �̳� Conductor ��ConductorBaseWithActiveItem ��ConductorBase ��Screen�� �����Ӵ���modelֱ�Ӽ̳�Screen
		d. ��MainView.xml ��  <ContentControl x:Name="ActiveItem" Margin="20"/> ��  MainViewModel.OnViewLoaded()�����
		var viewmodel = IoC.Get<CategoryViewModel>();
		return ActivateItemAsync(viewmodel, new CancellationToken());  ���Լ���CategoryViewModel ����ActiveItem���ܸĶ�
		e. Ϊ��ʹ����work����bootstrapper�� override void Configure() Ҫ���������õ��� ViewModel 
			private readonly SimpleContainer _container = new SimpleContainer();        
			protected override void Configure()
		        {
		            _container.Instance(_container);
		            _container
		              .Singleton<IWindowManager, WindowManager>()
		              .Singleton<IEventAggregator, EventAggregator>();
		
		            _container.Singleton<MyViewModel>();
			    // �������MainViewModel ���������޷����С����� ViewModel �粻���������޷���ʾ��
			}
	2. ��app.xaml ��ָ��resource dictionary
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
		a. xml�� <Button x:Name="Edit" Width="80" Margin="5">Edit</Button>  û��action��CM���ҵ�model���x:Name��ͬ���ֵķ�����Ϊaction�� �˴���Edit()��ͬʱ���� get  CanEdit  property������ Edit button�Ƿ� enable ��
		b. Ҳ������   cal:Message.Attach ��ʵ�� binding�� cal:Message.Attach="Edit()" ��ʱxmlͷ��Ҫ���� xmlns:cal="http://caliburnmicro.com"


</xmp