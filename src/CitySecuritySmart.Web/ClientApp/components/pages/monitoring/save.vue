<template>
  <div>
    <page-head
      icon="plus"
      title="New Monitoring"
    />
	  <div class="row mt-2 mb-2">
      <div class="col-sm-4 col-xl-3" v-for="(item, index) in videoList" :key="index">
          <div class="card mb-2">
            <div class="card-body bg-dark text-white">
              <div class="d-flex align-items-center">
                <div class="lnr lnr-cart display-4 text-success"></div>
                <div class="ml-3">
                  <div class="text-medium">{{item}}</div>
                </div>
              </div>
            </div>
          </div>
      </div>
    </div>
	  <template>
		  <cssi-text value= model.name placeholder = "Type your video name" v-model="model.name"/>
			<div class="text-center"><button @click="save" class="btn btn-success text mb-4 mt-4" >
			<icon icon="plus"/>	Save
			</button></div>
	  </template>
  </div>
</template>

<script>
import service from "service/monitoring";
import router from "@/router";
export default {
	data() {
		return {
			model: { 
				name: "",
			},
			videoList: []
		}
	},
	 async mounted() {
      var result = await service.list();
      if (result.data && result.data.length)
     	 this.videoList.push(...result.extendData);
    },
  methods: {
		async save() {
			var result = await service.save(this.model);
			console.log(result);
			if(result.code === 200){
					router.push({
						name: "monitoring-list"
					})
			}
		}
	}
};
</script> 

