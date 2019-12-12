<template>
  <div>
    <page-head icon="th-list" title="All Monitorings" />
	<div class="card mb-4">
			<div class="card-body">
			<div class="input-group">
			<input type="text" class="form-control " placeholder="Search video label" v-model="name"/>
			<router-link :to="detailList"><button class="btn btn-primary" type="button">Go!</button> </router-link>
			</div>
		</div>
	</div>

 <!-- Content -->
          <div class="container-fluid flex-grow-1 container-p-y">

            <h4 class="d-flex justify-content-between align-items-center w-100 font-weight-bold py-3 mb-4">
              <div>All List</div> 
              <router-link to="/monitoring/save">
				  <button type="button" class="btn btn-primary rounded-pill d-block"><span class="ion ion-md-add"></span>&nbsp; New Monitoring</button>
			  </router-link>
            </h4>


            <div class="card">
              <div class="card-datatable table-responsive">
                <table class="table table-striped table-bordered">
                  <thead class="thead-dark">
                    <tr>
					<th >Name</th>
                      <th>Label</th>
					  <th>Label Category</th>
					  <th>Start Time</th>
					  <th>End Time</th>
					  <th>Confidence</th>
                    </tr>
                  </thead>
				  <tbody v-for="(item, index) in monitorings" :key="index" class="table-dark">
					  <tr>
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
		name: "",
      }
	},

    async mounted() {
      var result = await service.list();
      if (result.data && result.data.length)
        this.monitorings.push(...result.data);
	},
	computed: {
		detailList(){
 			return `detail/${this.name}`;
		}
	}
  };

</script>
