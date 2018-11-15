J8M2Q-JNDGB-9B469-CTT26-TJGDY 
1. create BackgroundWorkder
	T:System.ComponentModel.BackgroundWorker
	
2. Setup BackgroundWorkder operation
	add an event handler for the E:System.ComponentModel.BackgroundWorker.DoWork event,Call your time-consuming operation in this event handler. 
	
3. Start the operation, 
	call M:System.ComponentModel.BackgroundWorker.RunWorkerAsync. 
	
4. To receive notifications of progress updates
	handle the E:System.ComponentModel.BackgroundWorker.ProgressChanged event. 
	
5. To receive a notification when the operation is completed, 
	handle the E:System.ComponentModel.BackgroundWorker.RunWorkerCompleted event.