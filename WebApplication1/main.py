import pixellib
import os

from pixellib.instance import custom_segmentation


files = os.listdir("D:\\pyVision")

filename = sorted(files)[-1]


segment_image = custom_segmentation()
segment_image.inferConfig(num_classes= 1, class_names= ["BG", "Container"], network_backbone="resnet50")
segment_image.load_model("D:\\pyVision\\mask_rcnn_model.028-0.502906.h5")
result = segment_image.segmentImage("D:/pyVision/"+filename,
                           show_bboxes=True
                           #output_image_name="sample_out.jpg",
                           #extract_segmented_objects=True,
                           #save_extracted_objects=True
                           )


print(result[0]['rois'])
