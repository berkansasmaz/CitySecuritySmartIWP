<template>
	<div>
		 <page-head icon="chart-line" title="Detail" />

		 <!-- Content -->
          <div class="container-fluid flex-grow-1 container-p-y">

            <h4 class="d-flex justify-content-between align-items-center w-100 font-weight-bold py-3 mb-4">
              	<div>Video Detail: {{name}}</div> 
              	<div class="btn-group" role="group">
  				<router-link to="/monitoring/save">
					  <button type="button" class="btn btn-primary rounded-pill d-block"><span class="ion ion-md-add"></span>&nbsp; New Monitoring</button>
				  </router-link>
						&nbsp; &nbsp; 
						<router-link to="/monitoring/list">
							<button class="btn btn-dark  rounded-pill d-block" type="button">
								Back to list
							</button>
						</router-link>
				  </div>
            </h4>

            <div class="card">
              <div class="card-datatable table-responsive">
                <table class="table table-hover table-bordered">
                  <thead class="thead-dark">
                    <tr>
					  <th>#</th>
					 <th>Name</th>
                      <th>Label</th>
					  <th>Label Category</th>
					  <th>Start Time</th>
					  <th>End Time</th>
					  <th>Confidence</th>
                    </tr>
                  </thead>
				  <tbody v-for="(item, index) in monitorings" :key="index">
					  <template  v-if="item.name===name" >
						  	<tr v-if="item.dangerLevel === 1" class="bg-danger">
								<td >{{index + 1}}</td>
								<td >{{item.name}}</td>
								<td>{{item.label}}</td>
								<td>{{item.labelCategory}}</td>
								<td>{{item.startTimeOffset}}</td>
								<td>{{item.endTimeOffset}}</td>
								<td>{{item.confidence}}</td>
							  </tr>
							<tr class="bg-info">
								<td>{{index + 1}}</td>
								<td>{{item.name}}</td>
								<td>{{item.label}}</td>
								<td>{{item.labelCategory}}</td>
								<td>{{item.startTimeOffset}}</td>
								<td>{{item.endTimeOffset}}</td>
								<td>{{item.confidence}}</td>
							  </tr>
					  </template>
				  </tbody>
                </table>
              </div>
            </div>
			<div class="card mb-4">
				<div class="embed-responsive embed-responsive-16by9">
					<iframe class="embed-responsive-item" :src=url allowfullscreen></iframe>
				</div>
  			</div>
          </div>
          <!-- / Content -->
	</div>
</template>
<script>
  import service from "service/monitoring";
  import router from "@/router";
  export default {
		data() {
			return {
				monitorings: [],
				name: `${this.$route.params.name}`,
				url: ""
			}
		},
		async mounted() {
			var result = await service.list();
			if (result.data && result.data.length)
				this.monitorings.push(...result.data);
		},
		created() {
				this.url = `https://storage.cloud.google.com/mts-bucket/${this.name}`;
				return this.url;
		}
  };

</script>
