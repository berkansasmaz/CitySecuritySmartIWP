<template>
	<div>
		 <page-head icon="chart-line" title="Detail" />

		 <!-- Content -->
          <div class="container-fluid flex-grow-1 container-p-y">

            <h4 class="d-flex justify-content-between align-items-center w-100 font-weight-bold py-3 mb-4">
              <div>Video Detail: {{name}}</div> 
              <button onclick="window.location.href='/monitoring/save'" type="button" class="btn btn-primary rounded-pill d-block"><span class="ion ion-md-add"></span>&nbsp; New Monitoring</button>
            </h4>


            <div class="card">
              <div class="card-datatable table-responsive">
                <table class="table table-hover table-bordered">
                  <thead>
                    <tr>
					<th >Name</th>
                      <th>Label</th>
					  <th>Label Category</th>
					  <th>Start Time</th>
					  <th>End Time</th>
					  <th>Confidence</th>
                    </tr>
                  </thead>
				  <tbody v-for="(item, index) in monitorings" :key="index">
					  <tr v-if="item.name===name">
						  <td>{{item.name}}</td>
						  <td>{{item.label}}</td>
						 	<td>{{item.labelCategory}}</td>
						  <td>{{item.startTimeOffset}}</td>
						  <td>{{item.endTimeOffset}}</td>
						  <td>{{item.confidence}}</td>
					  </tr>
				  </tbody>
                </table>
              </div>
            </div>
          </div>
          <!-- / Content -->
	</div>
</template>
<script>
  import service from "service/monitoring";
  export default {
		data() {
			return {
				monitorings: [],
				name: `${this.$route.params.name}`
			}
		},
		async mounted() {
		var result = await service.list();
		if (result.data && result.data.length)
			this.monitorings.push(...result.data);
		},
	
  };

</script>
