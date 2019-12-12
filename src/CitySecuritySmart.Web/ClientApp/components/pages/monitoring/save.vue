<template>
  <div>
    <page-head
      icon="plus"
      title="New Monitoring"
    />
	  <template>
		  <cssi-text value= model.name placeholder = "Type your video name" v-model="model.name"/>
			<button @click="save" class="btn btn-success" >
			<icon icon="plus"/>	Save
			</button>
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
			}
		}
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

