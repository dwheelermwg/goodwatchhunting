//
//  HealthManager.swift
//  GoodWatchHuntingApp
//
//  Created by Derek Wheeler on 12/9/15.
//  Copyright © 2015 MyWebGrocer. All rights reserved.
//

import Foundation
import HealthKit

public class HealthManager {
    let healthKitStore = HKHealthStore()
    
    func authorizeHealthKit(completion: ((success:Bool, error:NSError!) -> Void)!) {
        let healthKitReadTypes: Set<HKObjectType> = Set([
            HKObjectType.quantityTypeForIdentifier(HKQuantityTypeIdentifierBodyTemperature)!,
            HKObjectType.quantityTypeForIdentifier(HKQuantityTypeIdentifierRespiratoryRate)!,
            HKObjectType.quantityTypeForIdentifier(HKQuantityTypeIdentifierHeartRate)!
        ])
        
        if HKHealthStore.isHealthDataAvailable() {
            healthKitStore.requestAuthorizationToShareTypes(nil, readTypes: healthKitReadTypes, completion: { (success, error) -> Void in
                if success {
                    print("SUCCESS")
                } else {
                    print(error!.description)
                }
            })
        } else {
            print("HealthKit is not available.")
        }
    }
    
    func queryHeartRate() {
        
    }
}
